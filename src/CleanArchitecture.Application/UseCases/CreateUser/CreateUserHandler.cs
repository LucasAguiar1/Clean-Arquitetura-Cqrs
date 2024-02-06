using System;
using AutoMapper;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            _userRepository.Create(user);
            await _unitOfWork.Commit(cancellationToken);

            var aaa = _mapper.Map<CreateUserResponse>(user);

            return aaa;
        }
    }
}

