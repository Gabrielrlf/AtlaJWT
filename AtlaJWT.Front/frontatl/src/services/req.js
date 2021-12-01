import axios from 'axios'

const url = "https://localhost:44382/";
const JWT_Token = localStorage.getItem("JWT_Token");

class Req {

    login = (obj) => {
        return axios({
            method: 'post',
            url: `${url}api/User/Login`,
            data: JSON.stringify(obj),
            headers: {
                'Content-Type': "application/json"
            }
        })
    }

    getAllUser = () => {
        return axios.get(`${url}api/User/GetAll`, {
            headers: {
                'Content-Type': "application/json",
                'Authorization': 'Bearer ' + JWT_Token
            },
        })
    }

    updateUserRegistered = (obj) => {
        return axios({
            method: 'put',
            url: `${url}api/User/Update`,
            data: JSON.stringify(obj),
            headers: {
                'Content-Type': "application/json",
                'Authorization': 'Bearer ' + JWT_Token
            }
        })
    }

    createUserRegistered = (obj) => 
    {
        return axios({
            method: 'post',
            url: `${url}api/User/Create`,
            data: JSON.stringify(obj),
            headers: {
                'Content-Type': "application/json",
                'Authorization': 'Bearer ' + JWT_Token
            }
        })
    }

    removeUserRegistered = (id) => {
        return axios({
            method: 'delete',
            url: `${url}api/User/Remove/${id}`,
            headers: {
                'Content-Type': "application/json",
                'Authorization': 'Bearer ' + JWT_Token
            }
        })
    }
}

export default new Req();