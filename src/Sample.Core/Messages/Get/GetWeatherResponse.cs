// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using EnsureThat;
using Sample.Core.Features.Weather;

namespace Sample.Core.Messages.Get;

public class GetWeatherResponse
{
    public GetWeatherResponse(ICollection<WeatherForecast> weatherForecasts)
    {
        WeatherForecasts = EnsureArg.IsNotNull(weatherForecasts, nameof(weatherForecasts));
    }

    public ICollection<WeatherForecast> WeatherForecasts { get; }
}
