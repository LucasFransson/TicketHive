using System.Linq.Expressions;
using System.Reflection;
namespace TicketHive.Extensions

{
	public static class TEntityExtensions
	{

		public static string GetAPIName<TEntity>(this TEntity entity) where TEntity : class
		{
			string typeName = typeof(TEntity).Name;

			if (typeName.EndsWith("ViewModel"))
			{
				typeName = typeName.Substring(0, typeName.Length - 10);
			}

			if (typeof(TEntity).IsGenericType)
			{
				typeName = typeName.Substring(0, typeName.IndexOf('`'));
			}
			return $"{typeName}s";
		}
	}
}

		//public static string GetAPIName<TEntity>(this TEntity tEntity) where TEntity : class
		//{
		//	string typeName = typeof(TEntity).Name;
		//	if (typeName.EndsWith("ViewModel"))
		//	{
		//		return typeName.Substring(0, typeName.Length - 9) + "s";
		//	}
		//	else
		//	{
		//		throw new InvalidOperationException($"Invalid entity name. Entity name must end with 'ViewModel'. The entity name you've entered is:{typeName}");
		//	}
		//}

		//public static string GetAPIName<TEntity>(string type) where TEntity : class
		//{
		//	string typeName = typeof(TEntity).Name;
		//	if (typeName.EndsWith("ViewModel"))
		//	{
		//		return typeName.Substring(0, typeName.Length - 9) + "s";
		//	}
		//	else
		//	{
		//		throw new InvalidOperationException($"Invalid entity name. Entity name must end with 'ViewModel'. The entity name you've entered is:{typeName}");
		//	}
		//}