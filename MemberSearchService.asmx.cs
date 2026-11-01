using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using The18th.Areas.Cooperatives.CooperativeDTOs;

namespace The18th
{
    /// <summary>
    /// Summary description for MemberSearchService
    /// </summary>
    [WebService(Namespace = "https://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MemberSearchService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetMembers(string term)
        {


            string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
            List<CooperativeMemberDto> members = new List<CooperativeMemberDto>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetCoopMember", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@MemberName",
                    Value = term
                };
                cmd.Parameters.Add(paramId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                  CooperativeMemberDto member = new CooperativeMemberDto();   
                  member.Id = Convert.ToInt32(reader["Id"]);
                  member.MemberName = reader["MemberName"].ToString();
                  member.MemberImage = reader["MemberImage"].ToString();
                  members.Add(member);
                }


                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Context.Response.Write(serializer.Serialize(members));
                    

            }


                //return "Hello World";
        }




    }
}
