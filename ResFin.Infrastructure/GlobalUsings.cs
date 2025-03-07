﻿global using System.Data;
global using Dapper;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Npgsql;
global using ResFin.Application.Abstractions.Clock;
global using ResFin.Application.Abstractions.Data;
global using ResFin.Application.Abstractions.Email;
global using ResFin.Domain.Abstractions;
global using ResFin.Domain.Residences;
global using ResFin.Domain.Residences.Events.Reservations;
global using ResFin.Domain.Reviews;
global using ResFin.Domain.Shared;
global using ResFin.Domain.Users;
global using ResFin.Infrastructure.Clock;
global using ResFin.Infrastructure.Data;
global using ResFin.Infrastructure.Email;
global using ResFin.Infrastructure.Repositories;
global using ResFin.Application.Exceptions;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Extensions.Options;
global using ResFin.Infrastructure.Authentication.Models;
global using System.Net.Http.Json;
global using ResFin.Application.Abstractions.Authentication;
global using ResFin.Infrastructure.Authentication.Models;
global using System.Text.Json.Serialization;
