import React from 'react'
import { Modal, Button } from 'react-bootstrap';
import { Label, Input } from 'reactstrap';
import { showModalSwal, validateFields } from '../../shared/util'
import req from '../../services/req';

class ModalInsertUser extends React.Component {
    state = {
        userName: "",
        password: "",
        age: ""
    }

    ///Método que faz a inserção do usuário.
    insertUser = () =>
    {
        const { userName, password, age} = this.state;
        
        if(validateFields(userName, age, password))
        {
            return;
        }
            
        const obj = {
            userName, 
            password,
            age
        }

        req.createUserRegistered(obj).
        then(x =>
        {
            const { status, data } = x;
            if(status === 200)
            {
                showModalSwal("Usuário inserido", "success");
                this.props.closeModalInsert();
            }
        }).
        catch(x =>
        {
            showModalSwal(`Erro ao inserir usuário, tente novamente!${x.data}`, "error");
        })
    }

    render() {
        return (
            <Modal show={this.props.showModalInsert} onHide={() => this.props.closeModalInsert()}>
                <Modal.Header closeButton>
                    <Modal.Title>Inserir usuário</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Label>Nome de Usuário</Label>
                    <Input type="text"
                        id="user"
                        name="user"
                        placeholder="Usuário"
                        value={this.state.userName}
                        onChange={(e) => this.setState({ userName: e.target.value })}
                    />

                    <Label>Idade</Label>
                    <Input
                        type="number"
                        id="idade"
                        name="idade"
                        placeholder="idade"
                        value={this.state.age}
                        onChange={(e) => this.setState({ age: e.target.value })}
                    />

                    <Label>Senha</Label>
                    <Input
                        type="password"
                        id="password"
                        name="password"
                        placeholder="Senha"
                        value={this.state.password}
                        onChange={(e) => this.setState({ password: e.target.value })}
                    />
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="primary" onClick={() => this.insertUser()}>Salvar</Button>
                    <Button variant="secondary"
                        onClick={() => this.props.closeModalInsert()}>
                        Cancelar
                    </Button>
                </Modal.Footer>
            </Modal>
        )
    }
}

export default ModalInsertUser;