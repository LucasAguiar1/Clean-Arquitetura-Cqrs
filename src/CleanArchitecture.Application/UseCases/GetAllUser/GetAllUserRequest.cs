using System;
using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
	public sealed class GetAllUserRequest : IRequest<List<GetAllUserResponse>>
	{
		
	}
}

