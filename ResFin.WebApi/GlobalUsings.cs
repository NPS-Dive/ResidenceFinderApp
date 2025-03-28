﻿global using System.Net.Sockets;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using ResFin.Application;
global using ResFin.Application.Residences.SearchResidences;
global using ResFin.Infrastructure;
global using ResFin.WebApi.Extensions;
global using Bogus;
global using Dapper;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Http;
global using ResFin.Application.Abstractions.Data;
global using ResFin.Domain.Residences;
global using ResFin.Application.Exceptions;
global using Microsoft.EntityFrameworkCore;
global using ResFin.Application.Reservations.BookReservation;
global using ResFin.Application.Reservations.GetReservation;
global using ResFin.Application.Users.GetLoggedInUser;
global using ResFin.Application.Users.LoginUser;
global using ResFin.Application.Users.RegisterUser;
global using ResFin.Domain.Shared;
global using ResFin.Domain.Users;
global using ResFin.Infrastructure.Authorization;
global using ResFin.WebApi.Middleware;
global using Serilog.Context;
global using ValidationException = ResFin.Application.Exceptions.ValidationException;
