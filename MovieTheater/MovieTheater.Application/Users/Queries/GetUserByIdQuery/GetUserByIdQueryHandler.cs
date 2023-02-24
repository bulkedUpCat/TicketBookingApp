using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieTheater.Application.Exceptions.NotFoundException;
using MovieTheater.Application.Shared.User;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Users.Queries.GetUserByIdQuery;

public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, UserModel>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    
    public GetUserByIdQueryHandler(
        UserManager<User> userManager, 
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    
    public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString())
                   ?? throw new UserNotFoundException(request.Id);

        return _mapper.Map<UserModel>(user);
    }
}