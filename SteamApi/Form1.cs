using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Data.SqlClient;
namespace SteamApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string url = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=57206F9C19CBFC1415091BFED660EB72&steamids=" + txtSteamID.Text;
            Profile_ROOT steamUser = JsonConvert.DeserializeObject<Profile_ROOT>(new WebClient().DownloadString(url));
            picAvatar.ImageLocation = steamUser.response.players[0].avatarmedium;
            labPersonaName.Text = steamUser.response.players[0].personaname;
            labSteamID.Text = steamUser.response.players[0].steamid;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            DataTable check = getDataTableFromStoredProcedureWithVars("stpFindUser", new string[1, 3] {
                {"@steamid",labSteamID.Text,"varChar"}
            });
            if (check.Rows.Count == 0)
            {
                executeStoredProcedureWithVars("stpNewUser",new string[1, 3] {
                    {"@steamid",labSteamID.Text,"varChar"}
                });
                //we refind it to get userid
                check = getDataTableFromStoredProcedureWithVars("stpFindUser", new string[1, 3] {
                    {"@steamid",labSteamID.Text,"varChar"}
                });
                string userId = check.Rows[0]["userId"].ToString();
                //then we need to get games
                string url = "http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=57206F9C19CBFC1415091BFED660EB72&steamid="+check.Rows[0]["steamId"].ToString()+"&format=json";
                G_ROOT playerGame = JsonConvert.DeserializeObject<G_ROOT>(new WebClient().DownloadString(url));
                //then we need to add each game.
                for (int uth = 0; uth < playerGame.response.game_count; uth++)
                {
                    executeStoredProcedureWithVars("stpNewGame",new string[3, 3] {
                        {"@userId",userId,"int"},
                        {"@appId",playerGame.response.games[uth].appid.ToString(),"int"},
                        {"@playTime",playerGame.response.games[uth].playtime_forever.ToString(),"int"}
                    });
                }
            }
        }

        public static DataTable getDataTableFromStoredProcedureWithVars(string stp, string[,] vars)
        {
            //ok to explain how to operate this beast.(i will be making more of them...then making them faster.
            //stp is the name of the stored procedure
            //the array MUST be a [?,3] does nt matter how many row just make sure you have 3 data per line
            //[,0] is the name of the data the sql is expection: "@userId"
            //[,1] is the value of the data you wanna send: 1
            //[,2] is the type of data you are sending: varChar
            //follow the rules and you do not have to type your own function.
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection("Data Source=localhost;Persist Security Info=True;User ID=steamapi;Password=test");
            SqlCommand cmd = new SqlCommand(stp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int loop1 = 0; loop1 < vars.GetLength(0); loop1++)
            {
                //list of supported types
                //add one if you need it.
                switch (vars[loop1, 2])
                {
                    case "varChar":
                        cmd.Parameters.Add(vars[loop1, 0], SqlDbType.VarChar).Value = vars[loop1, 1];
                        break;
                    case "int":
                        cmd.Parameters.Add(vars[loop1, 0], SqlDbType.Int).Value = Int32.Parse(vars[loop1, 1]);
                        break;
                    case "decimal":
                        cmd.Parameters.Add(vars[loop1, 0], SqlDbType.Decimal).Value = Decimal.Parse(vars[loop1, 1]);
                        break;
                }
            }
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            try
            {
                cn.Open();
                data.Fill(dt);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
            try
            {
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void executeStoredProcedureWithVars(string stp, string[,] vars)
        {
            //[,0] is the name of the data the sql is expection: "@userId"
            //[,1] is the value of the data you wanna send: 1
            //[,2] is the type of data you are sending: varChar
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection("Data Source=localhost;Persist Security Info=True;User ID=steamapi;Password=test");
            SqlCommand cmd = new SqlCommand(stp, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int loop1 = 0; loop1 < vars.GetLength(0); loop1++)
            {
                //list of supported types
                //add one if you need it.
                switch (vars[loop1, 2])
                {
                    case "varChar":
                        cmd.Parameters.Add(vars[loop1, 0], SqlDbType.VarChar).Value = vars[loop1, 1];
                        break;
                    case "int":
                        cmd.Parameters.Add(vars[loop1, 0], SqlDbType.Int).Value = Int32.Parse(vars[loop1, 1]);
                        break;
                    case "decimal":
                        cmd.Parameters.Add(vars[loop1, 0], SqlDbType.Decimal).Value = Decimal.Parse(vars[loop1, 1]);
                        break;
                    case "tinyInt":
                        cmd.Parameters.Add(vars[loop1, 0], SqlDbType.TinyInt).Value = Boolean.Parse(vars[loop1, 1]);
                        break;
                }
            }
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cn.Close();
            }
        }
    }
    public class Player
    {
        public string steamid { get; set; }
        public int communityvisibilitystate { get; set; }
        public int profilestate { get; set; }
        public string personaname { get; set; }
        public int lastlogoff { get; set; }
        public string profileurl { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        public int personastate { get; set; }
        public string realname { get; set; }
        public string primaryclanid { get; set; }
        public int timecreated { get; set; }
        public int personastateflags { get; set; }
        public string loccountrycode { get; set; }
        public string locstatecode { get; set; }
        public int loccityid { get; set; }
    }
    public class theplayers
    {
        public List<Player> players { get; set; }
    }
    public class Profile_ROOT
    {
        public theplayers response { get; set; }
    }

    public class G_game
    {
        public int appid { get; set; }
        public int playtime_forever { get; set; }
    }
    public class G_games
    {
        public int game_count { get; set; }
        public List<G_game> games { get; set; }
    }
    public class G_ROOT
    {
        public G_games response { get; set; }
    }
}
