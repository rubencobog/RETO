package com.example.retodam2rutas.views

import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Scaffold
import androidx.compose.material3.TopAppBar
import androidx.compose.material3.TopAppBarDefaults.topAppBarColors
import androidx.compose.runtime.Composable
import androidx.navigation.NavController
import androidx.compose.ui.graphics.Color
import androidx.compose.material3.Text
import androidx.compose.ui.text.font.FontWeight
import com.example.retodam2rutas.components.ContentLoginView

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun LoginView(navController: NavController, loginViewModel: LoginViewModel){
    Scaffold(
        topBar = {
            TopAppBar(
                colors = topAppBarColors(
                    containerColor = Color(0xBA3AD271),
                    titleContentColor = Color(0xFF150033),
                ),
                title = {
                    Text(
                        text = "Reta Cantabria",
                        fontWeight = FontWeight.Bold
                    )
                }
            )
        },

        ) { innerPadding -> ContentLoginView(innerPadding, navController, loginViewModel) }
}

