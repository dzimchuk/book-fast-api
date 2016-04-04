namespace BookFast.Business
{
    public interface ISecurityContext
    {
        string GetCurrentUser();
        string GetCurrentTenant();
    }
}