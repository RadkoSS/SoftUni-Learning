function validator(request){
    const allowedMethods = [`GET`, `POST`, `DELETE`, `CONNECT`];
    const supportedVersions = [`HTTP/0.9`, `HTTP/1.0`, `HTTP/1.1`, `HTTP/2.0`];
    const propertiesNeeded = [`method`, `uri`, `version`, `message`];

    const specialCharacters = [`<`, `>`, `\\`, `&`, `'`, `"`];

    const uriRegEx = /^[\w.]+$/g;

    for(let property of propertiesNeeded){
        if(!request.hasOwnProperty(property)){
            if(property === `uri`){
                property = `URI`;
            }
            throw new Error(`Invalid request header: Invalid ${property[0].toUpperCase() + property.substring(1)}`);
        }
    }

    if(!allowedMethods.includes(request.method)){
        throw new Error(`Invalid request header: Invalid Method`);
    }

    if(!uriRegEx.test(request.uri) && request.uri !== `*`){
        throw new Error(`Invalid request header: Invalid URI`);
    }

    if(!supportedVersions.includes(request.version)){
        throw new Error(`Invalid request header: Invalid Version`);
    }

    for(let character of request.message){
        if(specialCharacters.includes(character)){
            throw new Error(`Invalid request header: Invalid Message`);
        }
    }

    return request;
}

let request = validator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}
);