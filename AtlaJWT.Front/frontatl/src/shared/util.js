import Swal from "sweetalert2";
import req from "../services/req";

export function showModalSwal(message, type) {
    Swal.fire({
        icon: type,
        title: message
    });
}

export function verifyIsNullOrEmpty(user, password) 
{
    if(user === "" || password === "")
    {
        return true;
    }

    return false;
}
