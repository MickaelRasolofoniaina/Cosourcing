﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cosourcing.RH.Services.Auth;
using Cosourcing.RH.Domain.Request.User;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService authService;

    public AuthController(AuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = authService.AuthenticateUser(request.Email, request.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        var token = authService.GenerateJwtToken(user);

        return Ok(new { Token = token });
    }

    // Autres actions pour l'inscription, la récupération de mot de passe, etc.
}