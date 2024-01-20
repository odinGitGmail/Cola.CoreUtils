using System.ComponentModel;
using Cola.CoreUtils.Constants;

namespace Cola.CoreUtils.Enums;

public enum EnumMediaType
{
    [Description(SystemConstant.CONSTANT_HTTP_MEDIATYPE_APPLICATION_JSON)]
    Json,
    [Description(SystemConstant.CONSTANT_HTTP_MEDIATYPE_APPLICATION_X_WWW_FORM_URLENCODED)]
    Urlencoded,
    [Description(SystemConstant.CONSTANT_HTTP_MEDIATYPE_MULTIPART_FORM_DATA)]
    FormData,
}