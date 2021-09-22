using System.Collections.Generic;

namespace SalesForce.Domain.Admin
{
    public class InvSuupplierEntity
	{
	    public int SL
	    {
	        get;
	        set;
	    }
        public string Opening
        {
            get;
            set;
        }
        public string OpeningDate
        {
            get;
            set;
        }
        public string Id
		{
			get;
			set;
		}
		public string Suppliername
		{
			get;
			set;
		}
		public string Address
		{
			get;
			set;
		}
		public string Contact
		{
			get;
			set;
		}
		public string Contactperson
		{
			get;
			set;
		}
		public string Contactpersondeatils
		{
			get;
			set;
		}
		public string Createdby
		{
			get;
			set;
		}
		public string Createddate
		{
			get;
			set;
		}
		public string Updatedby
		{
			get;
			set;
		}
		public string Updateddate
		{
			get;
			set;
		}

	    public string Email { get; set; }
	    public string CreditDays { get; set;}
	    public string ApprovalStatus { get; set; }
	    public string ApprovalDate { get; set; }
	    public string ApprovedBy { get; set; }
	    public string ReturnType { get; set; }

        public bool DashboardFirst { get; set; }

        public bool DashboardShow { get; set; }
        //public bool MisRmgTab { get; set; }
        //public string SrcShorting { get; set; }
        public string SrcStartDate { get; set; }
        public string SrcEndDate { get; set; }
        public string SrcMonth { get; set; }
        public string SrcYear { get; set; }

        public string ToptabPurchase { get; set; }
        public string ToptabPayment { get; set; }
        public string ToptabPayable { get; set; }
        public string ToptabTotalPayable { get; set; }
        public string ToptabSell { get; set; }
        public string ToptabCollection { get; set; }
        public string ToptabReceivable { get; set; }
        public string ToptabTotalReceivable { get; set; }

        public string ChartLabel { get; set; }
        public string ChartValue { get; set; }
        public string DtTableBody { get; set; }
        public string ToptabSellNoVatTax { get; set; }

        public List<InvSuupplierEntity> Notif { get; set; }
        public string NotifTitle { get; set; }
        public string NotifUrl { get; set; }
        public string NotifCount { get; set; }
        public string Flag { get; set; }
        public object SessionUserGUIId { get; set; }
        public bool isLedgerUpdate { get; set; }

        //=====================================Newly Added===========================================

        public string RegDate
        {
            get;
            set;
        }
        public string RegNo
        {
            get;
            set;
        }
        public string IsRegistered
        {
            get;
            set;
        }
        public string VatCategoryId
        {
            get;
            set;
        }
        public string MushakId
        {
            get;
            set;
        }
        public string OwnershipId
        {
            get;
            set;
        }
        public string EconomicActivityId
        {
            get;
            set;
        }
        public string CompanyCategoryId
        {
            get;
            set;
        }
        public string SupplierTypeId
        {
            get;
            set;
        }
        public string CountryId
        {
            get;
            set;
        }
        public string CurrencyId
        {
            get;
            set;
        }
        public string CurrencyName
        {
            get;
            set;
        }
        public string PaymentMethodId
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Region
        {
            get;
            set;
        }
        public string PostCode
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string AlternatePhone
        {
            get;
            set;
        }
        public string Facsimile
        {
            get;
            set;
        }
        public string Telex
        {
            get;
            set;
        }
        public string IsVendorAudited
        {
            get;
            set;
        }
        public string TLC
        {
            get;
            set;
        }
        public string VAT
        {
            get;
            set;
        }
        public string TIN
        {
            get;
            set;
        }
        public string NID
        {
            get;
            set;
        }
        public string BSC
        {
            get;
            set;
        }
        public string IsActive
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        public string VATCategoryName { get; set; }
        public string MushakName { get; set; }
        public string OwnershipName { get; set; }
        public string EconomicActivityName { get; set; }
        public string CompanyCategoryName { get; set; }
        public string SupplierTypeName { get; set; }
        public string CountryName { get; set; }
        public string PaymentMethodName { get; set; }
        public string BIN { get; set; }
        public string IsTurnover { get; set; }
        public string Is_Turnover { get; set; }
        public string Is_Registered { get; set; }
        public string CompanyStatus { get; set; }
    }
}

