namespace ResFin.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler (
        IAuthenticationService authenticationService,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
        )
        {
        _authenticationService = authenticationService;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        }

    public async Task<Result<Guid>> Handle (
        RegisterUserCommand request,
        CancellationToken cancellationToken )
        {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.Lastname),
            new Email(request.Email),
            new Phone(request.phone),
            new CellPhone(request.cellPhone),
           new Address(
               request.address.Country,
               request.address.StateOrProvince,
               request.address.City,
               request.address.Street,
               request.address.Alley,
               request.address.Number,
               request.address.ZipCode),
            new UserType()
            );

        var identityId = await _authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken
            );

        user.SetIdentityId(identityId);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id;
        }
    }