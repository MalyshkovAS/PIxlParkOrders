using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication2
{
    public class DeliveryAddress
    {
        public string ZipCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }

    public class Shipping
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }

    public class Result
    {

        public string Id { get; set; }
        public int PhotolabId { get; set; }
        public string CustomId { get; set; }
        public object SourceOrderId { get; set; }
        public string ManagerId { get; set; }
        public object AssignedToId { get; set; }
        public string Title { get; set; }
        public string TrackingUrl { get; set; }
        public object TrackingNumber { get; set; }
        public string Status { get; set; }
        public string RenderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public Shipping Shipping { get; set; }
        public int CommentsCount { get; set; }
        public string DownloadLink { get; set; }
        public string PreviewImageUrl { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public double PaidPrice { get; set; }
        public int UserId { get; set; }
        public int? UserCompanyAccountId { get; set; }
        public string DiscountTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DateReady { get; set; }
        public string LastDownloadedPaymentDocument { get; set; }
        public string PaymentSystemUniqueId { get; set; }
        public string GoogleClientId { get; set; }
        public object ContractorOrderNumber { get; set; }
        public double ContractorOrderTotalPrice { get; set; }
    }

    public class Root
    {
        public string ApiVersion { get; set; }
        public List<Result> Result { get; set; }
        public int ResponseCode { get; set; }
    }

}
