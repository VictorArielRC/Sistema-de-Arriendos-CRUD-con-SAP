# Normaliza comentarios en archivos .cs del proyecto
# Reglas aplicadas:
# - Ignorar comentarios de documentación '///'
# - Reemplazar frases comunes por una versión estándar en español
# - Capitalizar la primera letra del comentario
# - Asegurar que termine en punto si no termina en .,!?:;

$root = Get-Location
Write-Host "Normalizando comentarios en: $root" -ForegroundColor Cyan

$replacements = @{
    'Accede a códigos de otra librería' = 'Importa dependencias'
    'se utilizan para organizar el código' = 'Se utiliza para organizar el código'
    'se utiliza para organizar el código' = 'Se utiliza para organizar el código'
    'Cierra la clase' = 'Cierra la clase'
    'Cierra el namespace' = 'Cierra el namespace'
}

Get-ChildItem -Recurse -Filter *.cs | Where-Object { $_.FullName -notmatch '\\bin\\|\\obj\\' } | ForEach-Object {
    $path = $_.FullName
    $changed = $false
    $lines = Get-Content $path -Raw -Encoding UTF8 -ErrorAction SilentlyContinue
    if ($null -eq $lines) { return }

    $out = @()
    $lines -split "\r?\n" | ForEach-Object {
        $line = $_
        if ($line -match '^[\t ]*///') {
            # dejar comentarios de documentación XML intactos
            $out += $line
            return
        }
        if ($line -match '(^[\t ]*)(//+)(\s*)(.*)$') {
            $indent = $Matches[1]
            $slashes = $Matches[2]
            $rest = $Matches[4]

            # Solo procesar comentarios normales que empiezan con '//' (no más de 3 barras)
            if ($slashes.Length -le 3) {
                $text = $rest.Trim()
                # Aplica reemplazos exactos (buscando frase completa, ignorando mayúsc/minúsc)
                foreach ($k in $replacements.Keys) {
                    if ($text -match "(?i)^$k$" ) {
                        $text = $replacements[$k]
                        break
                    }
                }
                # Capitalizar primera letra si es letra
                if ($text.Length -gt 0) {
                    $first = $text.Substring(0,1)
                    if ($first -match '[a-záéíóúñ]') {
                        $text = $first.ToUpper() + $text.Substring(1)
                    }
                }
                # Añadir punto final si no termina en .,!?:; y no contiene 'http' ni '//' para caminos
                if ($text -ne '' -and $text -notmatch '[\.!\?\:;]$' -and $text -notmatch 'http' -and $text -notmatch '\\\\') {
                    $text = $text + '.'
                }
                $newLine = "$indent$slashes $text"
                if ($newLine -ne $line) { $changed = $true }
                $out += $newLine
                return
            }
        }
        $out += $line
    }

    if ($changed) {
        Set-Content -Path $path -Value ($out -join "`r`n") -Encoding UTF8
        Write-Host "Actualizado: $path" -ForegroundColor Green
    }
}

Write-Host "Normalización completada." -ForegroundColor Cyan
