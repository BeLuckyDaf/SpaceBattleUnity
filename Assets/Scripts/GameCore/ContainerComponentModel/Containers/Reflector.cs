using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;


namespace GameCore.ContainerComponentModel.Containers
{
    
    [System.AttributeUsage( System.AttributeTargets.Field )]
    [MeansImplicitUse]
    public sealed class Inject : System.Attribute
    {
    }
    
    public class InjectorException : System.Exception
    {
        public InjectorException( string message ) : base( message )
        {
        }
    }
    
    /// <summary>
    /// inspired by https://github.com/wooga/bi2_dependency_injection/blob/master/Assets/Injection/Injector.cs
    /// </summary>
    public static class Reflector
    {
        private static readonly System.Type _injectAttributeType = typeof(Inject);
        private static readonly Dictionary<System.Type, FieldInfo[]> cachedFieldInfos = new Dictionary<System.Type, FieldInfo[]>();
        private static readonly List<FieldInfo> _reusableList = new List<FieldInfo>( 1024 );
        
        public static FieldInfo[] Reflect(System.Type type)
        {
            if (cachedFieldInfos.TryGetValue( type, out var injectableFields ))
            {
                return injectableFields;
            }

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            for (var fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
            {
                var field = fields[ fieldIndex ];
                var hasInjectAttribute = field.IsDefined( _injectAttributeType, inherit: false );
                if (hasInjectAttribute)
                {
                    _reusableList.Add( field );
                }
            }
            var resultAsArray = _reusableList.ToArray();
            _reusableList.Clear();
            cachedFieldInfos[ type ] = resultAsArray;
            return resultAsArray;
        }
    }
}