namespace EmailApp.Domain
{
	public class EmailEntity
	{
		public string ToEmail { get; set; }
		public string ToDisplayName { get; set; }
		public string EmailSubject { get; set; }
		public string EmailBody { get; set; }
		public List<byte[]>? Attachments { get; set; }
	}
}
