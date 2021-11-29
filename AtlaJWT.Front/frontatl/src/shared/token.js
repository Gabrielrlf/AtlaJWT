const JWT_Token = localStorage.getItem("JWT_Token");

class Token {

    RegisterTokenJWT = (data) => {
        localStorage.setItem("JWT_Token", data.token);
        localStorage.setItem("Role", data.user.role);
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
        window.location.href = "/";

    }
}

export default new Token();