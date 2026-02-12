package com.example.retodam2rutas.views


import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import at.favre.lib.crypto.bcrypt.BCrypt
import com.example.retodam2rutas.data.database.AppDatabase
import com.example.retodam2rutas.data.service.BaseServiceFactory
import com.example.retodam2rutas.data.service.UsuarioServiceImpl
import com.example.retodam2rutas.entities.TIPOUSUARIO
import com.example.retodam2rutas.entities.Usuario
import com.example.retodam2rutas.model.UsuarioModel
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.flow.SharingStarted
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.stateIn
import kotlinx.coroutines.launch
import kotlin.math.log

class LoginViewModel(
    private val appDatabase: AppDatabase
) : ViewModel() {
    private val _usuario = MutableLiveData<Usuario>()
    val usuario: LiveData<Usuario> = _usuario
    val usuarioServiceImpl = UsuarioServiceImpl(BaseServiceFactory.createService(), appDatabase.usuarioDao())

    private val _loginSuccess = MutableStateFlow<Int>(0)
    val loginSuccess: StateFlow<Int> = _loginSuccess

    init {
        // Refresh from network
        viewModelScope.launch {
            usuarioServiceImpl.refreshUsers()
        }
    }

    fun getLoginUsuario(email: String, password: String){
        viewModelScope.launch {
            try {
                val getUser = appDatabase.usuarioDao().getLogin(email)

                val resultado = BCrypt.verifyer().verify(password.toCharArray(), getUser.password).verified


                if(resultado){

                    _usuario.value = getUser
                    _loginSuccess.value = 1
                }else{
                    _loginSuccess.value = 2
                }

            } catch (e: Exception) {
                e.printStackTrace()
                _loginSuccess.value = 2
            }
        }

    }

    fun resetLogin(){

            _loginSuccess.value = 0

    }

    fun setUsuarioInvitado(){
        _usuario.value = Usuario(
            -1,
            "invitado",
            "invitado",
            "invitado",
            "invitado",
            TIPOUSUARIO.usuario,

        )
    }


}