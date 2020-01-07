namespace ExBuddy.Plugins.Skywatcher
{
	using Clio.Utilities;
	using ExBuddy.Helpers;
	using ExBuddy.Interfaces;
	using ExBuddy.Plugins.Skywatcher.Providers;
	using ff14bot.Managers;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class SaintCoinachWeatherProvider : IWeatherProvider
	{
		private static readonly object Locker = new object();

		private static readonly IDictionary<int, int> ZoneMap = new Dictionary<int, int>
		{
			{-1, -1}, // Daidem Easy
			{-2, -2}, // Daidem
			{-3, -3}, // Daidem Hard
			{128, 28}, // Limsa Lominsa Upper Decks
			{129, 29}, // Limsa Lominsa Lower Decks
			{130, 40}, // Ul'dah - Steps of Nald
			{131, 41}, // Ul'dah - Steps of Thal
			{132, 52}, // New Gridania
			{133, 53}, // Old Gridania
			{134, 30}, // Middle La Noscea
			{135, 31}, // Lower La Noscea
			{137, 32}, // Eastern La Noscea
			{138, 33}, // Western La Noscea
			{139, 34}, // Upper La Noscea
			{140, 42}, // Western Thanalan
			{141, 43}, // Central Thanalan
			{144, 1484}, // The Gold Saucer
			{145, 44}, // Eastern Thanalan
			{146, 45}, // Southern Thanalan
			{147, 46}, // Northern Thanalan
			{148, 54}, // Central Shroud
			{152, 55}, // East Shroud
			{153, 56}, // South Shroud
			{154, 57}, // North Shroud
			{155, 63}, // Coerthas Central Highlands
			{156, 67}, // Mor Dhona
			{180, 350}, // Outer La Noscea
			{250, 358}, // Wolves' Den Pier
			{339, 425}, // Mist
			{340, 426}, // Lavender Beds
			{341, 427}, // Goblet
			{397, 2200}, // Coerthas Western Highlands
			{398, 2000}, // The Dravanian Forelands
			{399, 2001}, // The Dravanian Hinterlands
			{400, 2002}, // Churning Mists
			{401, 2100}, // Sea of Clouds
			{402, 2101}, // Azys Lla
			{418, 2300}, // Foundation
			{419, 2301}, // The Pillars
			{478, 2082}, // Idyllshire
			{612, 2406}, // The Fringes
			{613, 2409}, // The Ruby Sea
			{614, 2410}, // Yanxia
			{620, 2407}, // The Peaks
			{621, 2408}, // The Lochs
			{622, 2411}, // The Azim Steppe
			{628, 2404}, // Kugane
			{635, 2403} // Rhalgr's Reach
		};

		public bool IsEnabled { get; private set; }

		public byte CalculateRate(DateTime time)
		{
			var unixSeconds = Utilities.ConvertToUnixTimestamp(time);
			// Get Eorzea hour for weather start
			var bell = unixSeconds / 175;

			// Do the magic 'cause for calculations 16:00 is 0, 00:00 is 8 and 08:00 is 16
			var increment = (bell + 8 - (bell % 8)) % 24;

			// Take Eorzea days since unix epoch
			var eDays = unixSeconds / 4200;
			var totalDays = (((uint)eDays) << 32) >> 0;

			// 0x64 = 100
			var calcBase = totalDays * 100 + increment;

			// 0xB = 11
			var step1 = ((uint)((calcBase << 11) ^ calcBase)) >> 0;
			var step2 = ((step1 >> 8) ^ step1) >> 0;

			// 0x64 = 100
			return (byte)(step2 % 100);
		}

		#region IWeatherProvider Members

		public void Disable()
		{
			lock (Locker)
			{
				if (IsEnabled)
				{
					IsEnabled = false;
				}
			}
		}

		public void Enable()
		{
			lock (Locker)
			{
				if (!IsEnabled)
				{
					IsEnabled = true;
				}
			}
		}

		public int? GetCurrentWeatherByZone(int zoneId)
		{
			var location = LocationProvider.Instance.GetLocation(ZoneMap[zoneId]);

			if (location == null)
			{
				return null;
			}

			var date = WorldManager.EorzaTime;
			var localDate = SkywatcherPlugin.EorzeaToLocal(date);

			var rate = CalculateRate(localDate);

			var weatherRates = WeatherRateProvider.Instance.GetWeatherRates(location.WeatherRate);

			if (weatherRates == null)
			{
				return null;
			}

			var weatherRate = weatherRates.Rates.FirstOrDefault(r => rate < r.Rate);

			if (weatherRate == null)
			{
				return null;
			}

			return weatherRate.Weather;
		}

		public int? GetForecastByZone(int zoneId, TimeSpan timeSpan)
		{
			var location = LocationProvider.Instance.GetLocation(ZoneMap[zoneId]);

			if (location == null)
			{
				return null;
			}

			var date = WorldManager.EorzaTime + timeSpan;
			var localDate = SkywatcherPlugin.EorzeaToLocal(date);

			var rate = CalculateRate(localDate);

			var weatherRates = WeatherRateProvider.Instance.GetWeatherRates(location.WeatherRate);

			if (weatherRates == null)
			{
				return null;
			}

			var weatherRate = weatherRates.Rates.FirstOrDefault(r => rate < r.Rate);

			if (weatherRate == null)
			{
				return null;
			}

			return weatherRate.Weather;
		}

		#endregion IWeatherProvider Members
	}
}