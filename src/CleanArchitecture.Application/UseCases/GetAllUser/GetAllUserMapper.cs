using System;
using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
	public sealed class GetAllUserMapper : Profile
	{
		public GetAllUserMapper()
		{
			CreateMap<User, GetAllUserResponse>();
		}
	}
}

