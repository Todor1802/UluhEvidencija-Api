using System;

namespace UluhEvidencija.Contract
{
    public static class BaseEntityExtension
    {
        public static T MarkMetadata<T>(this T entity) where T : BaseEntity
        {
            if (entity.DateCreated.HasValue)
            {
                entity.DateEdited = DateTime.UtcNow;
            }
            else
            {
                entity.DateCreated = DateTime.UtcNow;
            }

            return entity;
        }

        public static T MarkMetadata<T>(this T entity, int? userId) where T : BaseEntity
        {
            if (entity.DateCreated.HasValue)
            {
                entity.DateEdited = DateTime.UtcNow;
                entity.EditorId = userId;
            }
            else
            {
                entity.DateCreated = DateTime.UtcNow;
                entity.CreatorId = userId;
            }

            return entity;
        }
    }
}
