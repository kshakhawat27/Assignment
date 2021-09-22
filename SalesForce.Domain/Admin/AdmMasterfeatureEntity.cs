namespace SalesForce.Domain.Admin
{
    public class AdmMasterfeatureEntity
	{
		public string Id
		{
			get;
			set;
		}

        public int SL1
        {
            get;
            set;
        }
		public string Modulename
		{
			get;
			set;
		}
		public string Tabname
		{
			get;
			set;
		}
		public string Url
		{
			get;
			set;
		}
		public string Sl
		{
			get;
			set;
		}
        public bool isDistinct { get; set; }
    }
}

