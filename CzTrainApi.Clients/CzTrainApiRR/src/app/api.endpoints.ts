export namespace ApiEndpoints {

    const host = 'https://localhost:44353/';

    export namespace Token {
        export const Get = host + 'Token/GetToken';
    }

    export namespace Intern {
        export namespace Katalog {
            export namespace Anrede {
                export const GettAll = host + 'AnredeKatalog/GetAll';
            }
        }
    }
}