using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Core.Models
{
    public class AddUpdateUserRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userName")]
        [Required]
        public string? UserName { get; set; }
        [JsonProperty("date")]
        [Required]
        public DateTime Date { get; set; }
        [JsonProperty("startdate")]
        [Required]
        public DateTime StartDate { get; set; }
        [JsonProperty("enddate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("subject")]
        [Required]
        public string? Subject { get; set; }
        [JsonProperty("description")]
        [Required]
        public string? Description { get; set; }
    }

    public class ApplicationUserListRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("UserName")]
        public string? UserName { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("startdate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("enddate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("subject")]
        public string? Subject { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class ApplicationUserResponseOutput
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
        public List<ApplicationUserDetailResponse>? applicationUserDetailResponses { get; set; }
    }

    public class ApplicationUserDetailResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("startdate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("enddate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("subject")]
        public string? Subject { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        public ApplicationUserDetailResponse()
        {
            this.Subject = Subject != null ? Subject.ToString() : "";
            this.UserName = UserName != null ? UserName.ToString() : "";
            this.Description = Description != null ? Description.ToString() : "";
        }
    }

    public class ApplicationUserListDetails : ApplicationUserDetailResponse
    {
        public int TotalRecord { get; set; }
    }

    //public class UserDetailRequest
    //{
    //    [JsonProperty("userId")]
    //    public string UserId { get; set; } 
    //}
    //public class UserDetailResponse
    //{
    //    [JsonProperty("userId")]
    //    public int Userid { get; set; }
    //    [JsonProperty("LastName")]
    //    public string LastName { get; set; }
    //    [JsonProperty("FirstName")]
    //    public string FirstName { get; set; }
    //    [JsonProperty("Email")]
    //    public string Email { get; set; }
    //    [JsonProperty("Role")]
    //    public int Role { get; set; }
    //    [JsonProperty("MarketId")]
    //    public int MarketId { get; set; }
    //}
}
