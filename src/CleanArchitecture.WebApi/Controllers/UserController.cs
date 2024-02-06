﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.DeleteUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Application.UseCases.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserResponse(), cancellationToken);
            
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResponse>> Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
                return BadRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            if (id is null)
                return BadRequest();
            var deleteUserRequest =new DeleteUserRequest(id.Value);

            var response = await _mediator.Send(deleteUserRequest, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            /*
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }*/

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}

