namespace LeaveManagementSystem.Application.Contract.Authenticate
{
    public enum SignInStatusEnum
    {
        OK,
        RequiresVerification,
        LockedOut,
        Unauthorized
    }
}
