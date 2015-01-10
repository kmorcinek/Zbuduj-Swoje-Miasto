using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using KMorcinek.TheCityCardGame.Utils;

namespace KMorcinek.TheCityCardGame
{
    public class AutoMapperConfig
    {
        static readonly Lazy<IMapper> LazyMapper = new Lazy<IMapper>(RegisterMappings);

        public static IMapper GetMapper()
        {
            return LazyMapper.Value;
        }

        static IMapper RegisterMappings()
        {
            var profiles = GetTypesFromAllAssemblies(typeof(Profile))
                .Select(t => (Profile)Activator.CreateInstance(t));

            var config = new MapperConfiguration(cfg => profiles.ForEach(cfg.AddProfile));

            AssertConfigurationInDebug(config);

            var mapper = config.CreateMapper();

            return mapper;
        }

        static IEnumerable<Type> GetTypesFromAllAssemblies(Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(
                    assembly => assembly.GetTypes()
                        .Where(t => t.IsSubclassOf(type)))
                .Where(t => t.IsNestedPrivate == false); // To exclude NamedProfile
        }

        [Conditional("DEBUG")]
        static void AssertConfigurationInDebug(IConfigurationProvider config)
        {
            config.AssertConfigurationIsValid();
        }
    }
}