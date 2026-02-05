package com.example.retodam2rutas.components

import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.PaddingValues
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.CircleShape
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.LocationOn
import androidx.compose.material3.AlertDialog
import androidx.compose.material3.Button
import androidx.compose.material3.CardColors
import androidx.compose.material3.CardDefaults
import androidx.compose.material3.ElevatedCard
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.runtime.DisposableEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.viewinterop.AndroidView
import androidx.navigation.NavController
import com.bumptech.glide.integration.compose.ExperimentalGlideComposeApi
import com.bumptech.glide.integration.compose.GlideImage
import com.example.retodam2rutas.R
import com.example.retodam2rutas.views.LoginViewModel
import com.example.retodam2rutas.entities.Ruta
import com.example.retodam2rutas.entities.maptemp.RutaTemporal
import com.example.retodam2rutas.entities.maptemp.TrackPoint
import com.example.retodam2rutas.model.UsuarioModel
import com.example.retodam2rutas.views.MapViewModel
import com.example.retodam2rutas.views.RutaViewModel
import org.osmdroid.util.GeoPoint
import org.osmdroid.views.MapView
import org.osmdroid.views.overlay.Marker
import org.osmdroid.views.overlay.Polyline
import java.io.File


//================ Contenido de la ventana home =================
@Composable
fun ContentHomeView(
    innerPadding: PaddingValues,
    navController: NavController,
    rutaViewModel: RutaViewModel) {
    LazyColumn (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        verticalArrangement = Arrangement.spacedBy(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        item {
            Text(
                text = "CATALOGO DE RUTAS",
                fontWeight = FontWeight.Bold,
                textAlign = TextAlign.Center,
                modifier = Modifier.fillMaxWidth(),
                color = Color.Black
            )
        }
        items(rutaViewModel.rutas){
            ruta ->
            RutaCard(ruta, navController)
        }
    }
}

//================ Contenido de la ventana detail =================
@Composable
fun ContentDetailView(
    innerPadding: PaddingValues,
    navController: NavController,
    id: Int,
    rutaViewModel: RutaViewModel) {

    rutaViewModel.cargarRuta(id)
    var ruta = rutaViewModel.rutaSeleccionada

    LazyColumn (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        verticalArrangement = Arrangement.spacedBy(16.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        item {
            Text(
                text = "Ruta",
                fontWeight = FontWeight.Bold,
                textAlign = TextAlign.Center,
                modifier = Modifier.fillMaxWidth(),
                color = Color.Black
            )
        }
        item {
            Button(
                onClick = { navController.navigate("Mapa/${ruta?.id}") }
            ) {
                Text("Iniciar ruta")
            }
        }
    }
}

//================ Contenido de la ventana GPS existente =================
@Composable
fun ContentMapView(
    innerPadding: PaddingValues,
    navController: NavController,
    id: Int,
    rutaViewModel: RutaViewModel,
    mapViewModel: MapViewModel
) {

    rutaViewModel.cargarRuta(id)
    val ruta = rutaViewModel.rutaSeleccionada

    val context = LocalContext.current
    val geoPoint = mapViewModel.lastGeoPoint

    val mapView = remember {
        MapView(context).apply {
            setMultiTouchControls(true)
            controller.setZoom(18.0)
        }
    }

    Column (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        verticalArrangement = Arrangement.spacedBy(26.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {

        DisposableEffect(Unit) {
            mapView.onResume()
            onDispose {
                mapView.onPause()
            }
        }

        AndroidView(
            modifier = Modifier
                .fillMaxWidth()
                .height(300.dp),
            factory = { mapView },
            update = {
                geoPoint?.let {
                    val marker = Marker(mapView).apply {
                        position = it
                        setAnchor(Marker.ANCHOR_CENTER, Marker.ANCHOR_BOTTOM)
                        title = "Mi ubicación"
                    }
                    mapView.overlays.clear()
                    mapView.overlays.add(marker)
                    mapView.controller.setCenter(it)
                    mapView.invalidate()
                }
            }
        )

        Row (
            modifier = Modifier
                .background(Color(0xFFD2E6F6))
                .fillMaxSize()
                .padding(innerPadding),
            verticalAlignment = Alignment.Bottom,
            horizontalArrangement = Arrangement.SpaceEvenly
        ){
            ButtonRuta(
                label = "Start",
                icon = R.drawable.play_circle,
                color = Color(0xCD4EC77D),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.iniciarRuta("Ruta1",geoPoint)
                    }
                }
            )
            ButtonRuta(
                label = "Stop",
                icon = R.drawable.stop_circle,
                color = Color(0xCD4EC77D),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.terminarRuta(geoPoint)
                    }
                }
            )
        }
    }
}

fun mostrarRuta(mapView: MapView, trackPoints: List<TrackPoint>) {
    val polyline = Polyline().apply {
        width = 5f
        color = android.graphics.Color.BLUE
        setPoints(trackPoints.map { GeoPoint(it.latitude, it.longitude) })
    }

    mapView.overlays.clear()
    mapView.overlays.add(polyline)
    if (trackPoints.isNotEmpty()) {
        mapView.controller.setCenter(GeoPoint(trackPoints.first().latitude, trackPoints.first().longitude))
    }
    mapView.invalidate()
}


//================ Contenido de la ventana GPS añadir =================
@Composable
fun ContentAddView(
    innerPadding: PaddingValues,
    navController: NavController,
    id: Int,
    rutaViewModel: RutaViewModel,
    mapViewModel: MapViewModel
) {

    val ruta = mapViewModel.rutaEnCreacion

    val context = LocalContext.current
    val geoPoint = mapViewModel.lastGeoPoint

    val mapView = remember {
        MapView(context).apply {
            setMultiTouchControls(true)
            controller.setZoom(18.0)
        }
    }
    var userMarker by remember { mutableStateOf<Marker?>(null) }
    var grabar by remember { mutableStateOf(false) }

    Column (
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize()
            .background(Color(0xFFD2E6F6)),
        verticalArrangement = Arrangement.spacedBy(26.dp),
        horizontalAlignment = Alignment.CenterHorizontally
    ) {

        DisposableEffect(Unit) {
            mapView.onResume()
            onDispose {
                mapView.onPause()
            }
        }

        AndroidView(
            modifier = Modifier
                .fillMaxWidth()
                .height(300.dp),
            factory = { mapView },
            update = {
                geoPoint?.let {
                    if (userMarker == null) {
                        userMarker = Marker(mapView).apply {
                            setAnchor(Marker.ANCHOR_CENTER, Marker.ANCHOR_BOTTOM)
                            title = "Mi ubicación"
                        }
                        mapView.overlays.add(userMarker)
                    }

                    mapViewModel.actualizarRuta(geoPoint)
                    userMarker!!.position = it
                    //mapView.overlays.clear() // Esto limpia el mapa de marcadores
                    mapView.controller.setCenter(it)
                    mapView.invalidate()
                }
                ruta.let {
                    if (it != null && grabar) {
                        actualizarLineaMapa(mapView,it)
                    }
                }
            }
        )

        Row (
            modifier = Modifier
                .background(Color(0xFFD2E6F6))
                .fillMaxSize()
                .padding(innerPadding),
            verticalAlignment = Alignment.Bottom,
            horizontalArrangement = Arrangement.SpaceEvenly
        ){
            ButtonRuta(
                label = "Start",
                icon = R.drawable.play_circle,
                color = Color(0xCD4EC77D),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.iniciarRuta("Ruta1",geoPoint)
                    }
                    grabar = true
                }
            )
            ButtonRuta(
                label = "Stop",
                icon = R.drawable.stop_circle,
                color = Color(0xCDC74E4E),
                onClick = {
                    if (geoPoint != null) {
                        mapViewModel.terminarRuta(geoPoint)
                    }
                    grabar = false
                }
            )
            Spacer(modifier = Modifier.width(10.dp))
            ButtonRuta(
                label = "Gpx",
                icon = R.drawable.outline_download,
                color = Color(0xCD4E6CC7),
                onClick = {
                    if(!grabar){
                        val gpxString = ruta?.let { mapViewModel.exportarGPX(it) }
                        val file = File(context.filesDir, "${ruta?.nombre}.gpx")
                        if (gpxString != null) {
                            file.writeText(gpxString)
                        }
                    }
                }
            )
        }
    }
}

fun actualizarLineaMapa(mapView: MapView, ruta: RutaTemporal) {
    mapView.overlays.removeAll { it is Polyline }

    val polyline = Polyline().apply {
        width = 5f
        color = android.graphics.Color.RED
        setPoints(ruta.trackPoints.map { GeoPoint(it.latitude, it.longitude) })
    }

    mapView.overlays.add(polyline)
    mapView.invalidate()
}

//================ Card de Rutas =================
@OptIn(ExperimentalGlideComposeApi::class)
@Composable
fun RutaCard(ruta: Ruta, navController: NavController) {
    ElevatedCard(
        elevation = CardDefaults.cardElevation(
            defaultElevation = 6.dp
        ),
        modifier = Modifier
            .fillMaxWidth()
            .padding(8.dp)
            .clickable { navController.navigate("Detail/${ruta.id}") },
        colors = CardColors(
            containerColor = Color.Black,
            contentColor = Color.White,
            disabledContainerColor = Color.Gray,
            disabledContentColor = Color.White
        ),
        shape = CardDefaults.shape,
    ) {
        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(12.dp),
            verticalAlignment = Alignment.CenterVertically
        ) {
            GlideImage(
                model = Icons.Default.LocationOn,
                contentDescription = "descripcion ruta",
                modifier = Modifier
                    .size(80.dp)
                    .clip(CircleShape)
                    .background(Color.LightGray)
            )

            Spacer(modifier = Modifier.width(16.dp))

            Column(
                modifier = Modifier.weight(1f)
            ) {
                Text(
                    text = ruta.nombre,
                    style = MaterialTheme.typography.titleMedium
                )
                Text(
                    text = "Distancia: ${ruta.distancia}m",
                    style = MaterialTheme.typography.bodyMedium
                )
                Text(
                    text = "Dificultad: ${ruta.nivelEsfuerzo}m",
                    style = MaterialTheme.typography.bodyMedium
                )
                Text(
                    text = "Valoracion: ${ruta.mediaEstrellas}m",
                    style = MaterialTheme.typography.bodyMedium
                )
            }
        }
    }
}

//================ Contenido de la ventana Login =================
@Composable
fun ContentLoginView(
    innerPadding: PaddingValues,
    navController: NavController,
    loginViewModel: LoginViewModel
) {
    val usuario: UsuarioModel? by loginViewModel.usuario.observeAsState()
    var email by remember { mutableStateOf("") }
    var password by remember { mutableStateOf("") }

    Column(
        modifier = Modifier
            .padding(innerPadding)
            .fillMaxSize(),
        horizontalAlignment = Alignment.CenterHorizontally,
        verticalArrangement = Arrangement.Center
    ) {
        Text("Iniciar sesión")

        Spacer(modifier = Modifier.padding(10.dp))

        TextField(
            value = email,
            onValueChange = { email = it },
            label = { Text("Usuario") },
            singleLine = true
        )

        Spacer(modifier = Modifier.padding(10.dp))

        TextField(
            value = password,
            onValueChange = { password = it },
            label = { Text("Contraseña") },
            singleLine = true,
            visualTransformation = PasswordVisualTransformation()
        )

        Spacer(modifier = Modifier.padding(10.dp))

        Button(onClick = { navController.navigate("Home") }) {
            Text("Entrar")
        }

    }
}

//================ Dialog de informacion =================
@Composable
fun DialogoInformativo(
    titulo: String,
    mensaje: String,
    onCerrar: () -> Unit
) {
    AlertDialog(
        onDismissRequest = onCerrar,
        title = { Text(titulo) },
        text = { Text(mensaje) },
        confirmButton = {
            TextButton(onClick = onCerrar) {
                Text("Aceptar")
            }
        }
    )
}