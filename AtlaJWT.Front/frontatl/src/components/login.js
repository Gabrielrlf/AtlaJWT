import React from 'react'
import { Button, Label, Input } from 'reactstrap';
import { showModalSwal, verifyIsNullOrEmpty } from '../shared/util'
import { FaList, FaSignInAlt } from 'react-icons/fa';
import req from '../services/req';
import token from '../shared/token';
import swal from 'sweetalert2';
import "../style/style.css"

class Login extends React.Component {
    state = {
        userName: "",
        password: "",
    }

    componentDidMount = () => {
       token.isAutenticate();

    }

    login = () => {
        const { userName, password } = this.state;

        if(verifyIsNullOrEmpty(userName, password)) 
        {
            showModalSwal("O campo usuário ou senha está em branco!", "warning")
            return;
        }

        const obj = {
            "UserName": userName,
            "Password": password
        }

        req.login(obj).then(result => {

            if (result.status === 200) {
                token.RegisterUserStorage(result.data)
                token.isAutenticate();
            }

            this.showModalSwal("Bem-vindo", "success")
        }).catch(this.showModalSwal("Usuário ou senha inválido", "error"));
    }

    showModalSwal = (message, type) => {
        swal.fire({
            icon: type,
            title: message
        });
    }


    render() {
        return (
            <div>
                <h2>Login - Acesso ao sistema</h2>
                <Label>Usuário</Label>
                <Input type="text"
                    id="user"
                    name="user"
                    placeholder="Usuário"
                    value={this.state.userName}
                    onChange={(e) => this.setState({ userName: e.target.value })}
                    required={true}
                />

                <Label>Senha</Label>
                <Input
                    type="password"
                    id="password"
                    name="password"
                    placeholder="Senha"
                    value={this.state.password}
                    onChange={(e) => this.setState({ password: e.target.value })}
                    required={true}
                />
                <Button variant="secondary" onClick={() => this.login()} className="space-bottom space-top"><FaSignInAlt /> Login</Button>
                <Button variant="secondary" onClick={() => window.location.href = "/list"} className="space-bottom space-top"><FaList /> Lista</Button>
            </div>
        )
    }
}

export default Login;