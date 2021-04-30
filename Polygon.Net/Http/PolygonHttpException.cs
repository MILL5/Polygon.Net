using System;

namespace Polygon.Net
{
    public class PolygonHttpException : Exception
    {
        public PolygonHttpException(string message)
        : base(message)
        {
        }
    }
}