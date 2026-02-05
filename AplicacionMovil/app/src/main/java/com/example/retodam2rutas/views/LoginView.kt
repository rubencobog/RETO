package com.example.retodam2rutas.views

import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TopAppBar
import androidx.compose.material3.TopAppBarDefaults.topAppBarColors
import androidx.compose.runtime.Composable
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.tooling.preview.PreviewParameter
import androidx.navigation.NavController
import com.example.retodam2rutas.components.ContentLoginView
import com.example.retodam2rutas.components.ContentMapView

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun LoginView(navController: NavController, loginViewModel: LoginViewModel){
    Scaffold(
        topBar = {
            TopAppBar(
                colors = topAppBarColors(
                    containerColor = Color(0xFF041B57),
                    titleContentColor = Color(0xFFC0D1F1),
                ),
                title = {
                    Text("Reta Cantabria")
                }
            )
        },

        ) { innerPadding -> ContentLoginView(innerPadding, navController, loginViewModel) }
}

