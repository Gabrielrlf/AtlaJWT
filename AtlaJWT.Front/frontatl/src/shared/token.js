const JWT_Token = localStorage.getItem("JWT_Token");

class Token {

    RegisterUserStorage = (data) => {
        localStorage.setItem("JWT_Token", data.token);
        localStorage.setItem("Role", data.user.role);
        localStorage.setItem("ID", data.user.id);
    }

    RemoveTokenJWT = () => {
        localStorage.clear();
    }

    isAutenticate = () => {
        if (localStorage.getItem("JWT_Token") !== null)
        {
            window.location.href = "/list"
        }
    }

    isAdminOrUser = () => {
        debugger
        if (localStorage.getItem("Role") === "Admin")
            return true;

        return false;
    }

    logout = () => {
        localStorage.removeItem("JWT_Token");
        localStorage.removeItem("Role");
        localStorage.removeItem("ID");
        window.location.href = "/";

    }
}

export default new Token();