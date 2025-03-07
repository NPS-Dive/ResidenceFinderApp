﻿global using Dapper;
global using FluentValidation;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using ResFin.Application.Abstractions.Behaviors;
global using ResFin.Application.Abstractions.Clock;
global using ResFin.Application.Abstractions.Data;
global using ResFin.Application.Abstractions.Email;
global using ResFin.Application.Abstractions.Messeging;
global using ResFin.Application.Exceptions;
global using ResFin.Domain.Abstractions;
global using ResFin.Domain.Residences;
global using ResFin.Domain.Residences.Events.Reservations;
global using ResFin.Domain.Residences.Events.Reservations.Events;
global using ResFin.Domain.Users;
global using ResFin.Application.Abstractions.Authentication;
global using ResFin.Domain.Shared;
