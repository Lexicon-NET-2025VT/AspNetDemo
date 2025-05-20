namespace AspNetDemo.Web.Views.Companies;

public class IndexVM
{
    public required CompanyItemVM[] CompanyItems { get; set; }
    public class CompanyItemVM
    {
        public required string CompanyName { get; set; }
    }
}