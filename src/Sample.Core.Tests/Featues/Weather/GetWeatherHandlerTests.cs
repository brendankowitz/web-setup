// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Sample.Core.Features.Weather;
using Sample.Core.Messages.Get;
using Xunit;

namespace Sample.Core.Tests.Featues.Weather;

public class GetWeatherHandlerTests
{
    private readonly GetWeatherHandler _handler;

    public GetWeatherHandlerTests()
    {
        _handler = new GetWeatherHandler();
    }

    [Fact]
    public async Task GivenAValidRequest_WhenRequestingWeather_ThenWeatherForecastsAreReturned()
    {
        GetWeatherResponse response = await _handler.Handle(new GetWeatherRequest(), CancellationToken.None);

        Assert.NotEmpty(response.WeatherForecasts);
    }
}
