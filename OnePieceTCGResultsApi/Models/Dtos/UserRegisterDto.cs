﻿namespace OnePieceTCGResultsApi.Models.Dtos;

public class UserRegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}