﻿using System.ComponentModel;

namespace Cola.CoreUtils.Enums;

public enum EnumException
{
    
    /// <summary>
    ///     Service Inject is null
    /// </summary>
    [Description("Service Inject is null")] ServiceInjectIsNull,
    
    /// <summary>
    ///     cert not null
    /// </summary>
    [Description("cert not null")] CertNotNull,
    
    /// <summary>
    ///     key not exist
    /// </summary>
    [Description("param can not be null")] KeyNotExists,
    
    /// <summary>
    ///     param can not be null
    /// </summary>
    [Description("param can not be null")] ParamNotNull,

    /// <summary>
    ///     param can not be null
    /// </summary>
    [Description("parameter validation failed")]
    ParamValidationFailed,

    /// <summary>
    ///     parameter type Incorrect
    /// </summary>
    [Description("parameter type Incorrect")]
    ParamTypeIncorrect,

    /// <summary>
    ///     param can not less than or equal to zero
    /// </summary>
    [Description("parameter out of range")]
    ParamOutOfRang,

    /// <summary>
    ///     param can not less than or equal to zero
    /// </summary>
    [Description("param can not Less than or equal to zero")]
    ParamNotLteZero,

    /// <summary>
    ///     param can not less than to zero
    /// </summary>
    [Description("param can not Less than or equal to zero")]
    ParamNotLtZero,

    /// <summary>
    ///     param can not Greater than or equal to zero
    /// </summary>
    [Description("param can not Greater than or equal to zero")]
    ParamNotGteZero,

    /// <summary>
    ///     param can not Greater than to zero
    /// </summary>
    [Description("param can not Greater than or equal to zero")]
    ParamNotGtZero,

    #region sqlsugar

    /// <summary>
    ///     AopOnLogExecuting 个数配置不正确
    /// </summary>
    [Description("AopOnLogExecuting 个数配置不正确")] SqlSugarAopExecutingParamNumberFailed,
    
    /// <summary>
    ///     AopOnLogExecuting 配置不正确
    /// </summary>
    [Description("AopOnLogExecuting 配置不正确")] SqlSugarAopExecutingParamsFailed,
    
    /// <summary>
    ///     ColaEfConfig 配置不正确
    /// </summary>
    [Description("ColaEfConfig 配置不正确")] ColaEfConfigFailed,
    
    /// <summary>
    ///     AopOnError 配置不正确
    /// </summary>
    [Description("AopOnError 配置不正确")] AopOnErrorFailed,
    
    /// <summary>
    ///     SqlSugar 多库配置 ConfigId 必须配置
    /// </summary>
    [Description("SqlSugar 多库配置 ConfigId 必须配置")] SqlSugarMustNeedConfigId,

    #endregion
    
    #region snowflake 雪花ID相关错误描述

    /// <summary>
    ///     雪花 DatacenterId 长度有错误
    /// </summary>
    [Description("datacenter Id can't be greater than {0} or less than 0")]
    SnowFlakeDatacenterIdLengthGtOrLt,

    /// <summary>
    ///     雪花 DatacenterId 长度有错误
    /// </summary>
    [Description("worker Id can't be greater than {0} or less than 0")]
    SnowFlakeWorkerIdLengthGtOrLt,
    
    /// <summary>
    ///     雪花 Inject config 有错误
    /// </summary>
    [Description("snowFlake Inject config is null")]
    SnowFlakeInjectConfigIsNull,

    #endregion

    #region webapi
    
    /// <summary>
    ///     HttpClient 自定义配置文件 ClientName 不能命名为 default
    /// </summary>
    [Description("HttpClient 配置 ClientName")] HttpClientNotHaveClientName,

    /// <summary>
    ///     HttpClient 自定义配置文件 ClientName 不能命名为 default
    /// </summary>
    [Description("HttpClient 自定义配置文件 ClientName 不能命名为 default")] HttpClientClientNameIsDefault,
    
    /// <summary>
    ///     HttpClient 自定义配置文件 ClientName 不能命名为 default
    /// </summary>
    [Description("HttpClient 自定义配置文件 ClientName 不能命名为 default")] HttpClientClientNameIsNotDefault,
    
    /// <summary>
    ///     HttpClient 自定义配置文件 Decompression 只可以配置为 None,GZip,Deflate,Brotli,All 其中的一项
    /// </summary>
    [Description("HttpClient 自定义配置文件 Decompression 只可以配置为 None,GZip,Deflate,Brotli,All 其中的一项")] HttpClientDecompressionFailed,

    #endregion

    #region OdinModels.Core

    /// <summary>
    ///     Config Url is undefind
    /// </summary>
    [Description("Config Url is undefind")]
    GetServiceUrlConfigByProtocol,

    #endregion

    #region OdinModels.OdinUtils

    /// <summary>
    ///     Invalid XML RSA key
    /// </summary>
    [Description("Invalid XML RSA key")] FromXmlStringEx,

    /// <summary>
    ///     Invalid Public Key
    /// </summary>
    [Description("Invalid Public Key")] RsaEncrypt,

    /// <summary>
    ///     Invalid Private Key
    /// </summary>
    [Description("IInvalid Private Key")] RsaDecrypt,

    /// <summary>
    ///     key 需要 32 位长度
    /// </summary>
    [Description("key 需要 32 位长度")] EncryptByAesX01,

    /// <summary>
    ///     如要使用 aes_ai 偏移量参数，必须要有加密盐值参数 key
    /// </summary>
    [Description("如要使用 aes_ai 偏移量参数，必须要有加密盐值参数 key")]
    EncryptByAesX02,

    /// <summary>
    ///     aes_ai 需要 16 位长度
    /// </summary>
    [Description("aes_ai 需要 16 位长度")] EncryptByAesX03,

    /// <summary>
    ///     key 需要 32 位长度
    /// </summary>
    [Description("key 需要 32 位长度")] DecryptByAesX01,

    /// <summary>
    ///     如要使用 aes_ai 偏移量参数，必须要有加密盐值参数 key
    /// </summary>
    [Description("如要使用 aes_ai 偏移量参数，必须要有加密盐值参数 key")]
    DecryptByAesX02,

    /// <summary>
    ///     aes_ai 需要 16 位长度
    /// </summary>
    [Description("aes_ai 需要 16 位长度")] DecryptByAesX03,

    #endregion

    #region regex

    /// <summary>
    ///     邮箱格式不正确
    /// </summary>
    [Description("邮箱格式不正确")] RegexEmail,

    /// <summary>
    ///     身份证格式不正确
    /// </summary>
    [Description("邮箱格式不正确")] RegexIdCardNumber,

    /// <summary>
    ///     移动电话号码格式不正确
    /// </summary>
    [Description("邮箱格式不正确")] RegexPhoneNumber,

    #endregion

    #region Jwt

    /// <summary>
    ///     refreshToken is null
    /// </summary>
    [Description("refreshToken is null")]
    RefreshTokenIsNull,
    
    /// <summary>
    ///     Invalid Token 无效的token
    /// </summary>
    [Description("Invalid Token")]
    InvalidToken,
    
    /// <summary>
    ///     Token Expire token过期
    /// </summary>
    [Description("Token Expire")]
    TokenExpire,
    
    /// <summary>
    ///     Invalid RefreshToken 无效的refresh_token
    /// </summary>
    [Description("Invalid RefreshToken")]
    InvalidRefreshToken,
    
    /// <summary>
    ///     RefreshToken Expire refresh_token已过期
    /// </summary>
    [Description("RefreshToken Expire")]
    RefreshTokenExpire,
    
    /// <summary>
    ///     RefreshToken Nullified refresh_token已失效
    /// </summary>
    [Description("RefreshToken Nullified")]
    RefreshTokenNullified,
    
    /// <summary>
    ///     RefreshToken Used refresh_token已使用
    /// </summary>
    [Description("RefreshToken Used")]
    RefreshTokenUsed,
    
    /// <summary>
    ///     RefreshToken Validate JwtId Fail token 与 refresh_token不一致
    /// </summary>
    [Description("RefreshToken Validate JwtId Fail")]
    RefreshTokenValidateJwtIdFail,
    
    #endregion
}