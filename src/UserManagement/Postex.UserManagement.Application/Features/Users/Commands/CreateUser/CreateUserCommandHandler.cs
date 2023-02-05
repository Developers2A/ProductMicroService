using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Postex.SharedKernel.Interfaces;
using ProductService.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IWriteRepository<User> _cityWriteRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public CreateUserCommandHandler(IWriteRepository<User> cityWriteRepository, IMapper mapper, UserManager<User> userManager)
    {
        _cityWriteRepository = cityWriteRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userWithSameEmail == null)
        {
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            //return  new(true, "success", $"User Registered with username {user.UserName}");
        }
        else
        {
            //return new(false, "fail", $"Email {user.Email} is already registered.");
        }
        return Unit.Value;
    }
}
