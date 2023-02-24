using MediatR;
using MovieTheater.Application.Shared.User;

namespace MovieTheater.Application.Users.Queries.GetUserByIdQuery;

public class GetUserByIdQuery: IRequest<UserModel>
{
    public Guid Id { get; set; }
}