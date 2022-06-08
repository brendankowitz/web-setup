// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using EnsureThat;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Core.Features.Weather;
using Sample.Core.Messages.Get;

namespace Sample.Api.Features.Weather;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _mediator = EnsureArg.IsNotNull(mediator, nameof(mediator));
        _logger = EnsureArg.IsNotNull(logger, nameof(logger));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "Sample")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        GetWeatherResponse request = await _mediator.Send(new GetWeatherRequest());
        return request.WeatherForecasts;
    }
}
