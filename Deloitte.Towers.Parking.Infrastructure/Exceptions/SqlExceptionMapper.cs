using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public static class SqlExceptionMapper
    {
        private static readonly Dictionary<SqlExceptionCode, BusinessException> BusinessExceptionMappingTable = new Dictionary<SqlExceptionCode, BusinessException>
            {
                {SqlExceptionCode.Unknown, new SqlUnknownException()},
                {SqlExceptionCode.EntityNotFound, new EntityNotFoundException()},
                {SqlExceptionCode.EntityDetailsNotFound, new EntityDetailsNotFoundException()},
                {SqlExceptionCode.EntityAlreadyExists, new EntityAlreadyExistsException()},
                {SqlExceptionCode.DependedEntityExists, new DependedEntityExistsException()},
                {SqlExceptionCode.InvalidParameterValue, new InvalidParameterValueException()},
                {SqlExceptionCode.SurveyQuestionModification, new SurveyQuestionModificationException()},
                {SqlExceptionCode.PermissionDenied, new PermissionDeniedException()},
                {SqlExceptionCode.DependentEntitiesNotExist, new DependentEntitiesNotExistException()},             
                {SqlExceptionCode.BuildingAlreadyExists, new BuildingAlreadyExistsException()},
                {SqlExceptionCode.LevelAlreadyExists, new LevelAlreadyExistsException()}
            };

        public static BusinessException TryExtractBusinessException(SqlExceptionCode sqlExceptionCode)
        {
            return BusinessExceptionMappingTable.ContainsKey(sqlExceptionCode)
                ? BusinessExceptionMappingTable[sqlExceptionCode]
                : new SqlUnknownException();
        }
    }
}
