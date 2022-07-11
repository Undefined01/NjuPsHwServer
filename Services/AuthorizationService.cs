namespace NjuCsCmsHelper.Server.Services;

public class OwnerOrAdminRequirement : IAuthorizationRequirement
{
    public static OwnerOrAdminRequirement Instance = new();
}

public class MyAuthorizationHandler : AuthorizationHandler<OwnerOrAdminRequirement, int>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   OwnerOrAdminRequirement requirement, int resource)
    {
        if (context.User.FindFirstValue(AppUserClaims.StudentId) == resource.ToString() ||
            context.User.IsInRole("Admin"))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
