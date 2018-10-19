export class Post {
    username: string;
    message: string;
    datum: Date;

    constructor(username: string = '', message: string = '') {
        this.username = username;
        this.message = message;
    }
}
