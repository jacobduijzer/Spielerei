using System;

namespace CustomMapper.Core
{
    public class CustomMapper
    {
        private Func<string, bool> _stringToBoolMapper;
        private Func<string, object> _genericMapper;
        private Type _type;

        public bool Map(Func<string, bool> mapper, string value) =>
            mapper(value);

        public void WithMapStringToBool(Func<string, bool> stringToBoolMapper) =>
            _stringToBoolMapper = stringToBoolMapper;

        public bool MapStringToBool(string value) =>
            _stringToBoolMapper(value);

        public T MapStringToObject<T>(Func<string, object> mapper, string value) =>
            (T)mapper(value);

        public void WithGenericMapper(Func<string, object> genericMapper) =>
            _genericMapper = genericMapper;

        public void WithType(Type type) =>
            _type = type;

        public T GenericMapper<T>(string value) =>
            (T)_genericMapper(value);

        public dynamic DynamicMapper(string value) =>
            _genericMapper(value);
    }
}