Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports RTUpdater.UpdaterControl
Public Class main
    'WINDOWS AERO
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MARGINS
        Public Destra As Integer
        Public Sinistra As Integer
        Public Su As Integer
        Public Giu As Integer
    End Structure
    'Declaration
    <BindableAttribute(True)> _
    Public Property Checked As Boolean
    'Usage
    Dim instance As RadioButton
    Dim value As Boolean
    Declare Auto Function DwmIsCompositionEnabled Lib "dwmapi.dll" Alias "DwmIsCompositionEnabled" (ByRef pfEnabled As Boolean) As Integer
    Declare Auto Function DwmExtendFrameIntoClientArea Lib "dwmapi.dll" Alias "DwmExtendFrameIntoClientArea" (ByVal hWnd As IntPtr, ByRef pMargin As MARGINS) As Integer
    Dim pMargins As New MARGINS With {.Su = 10, .Sinistra = -1, .Destra = -1, .Giu = -1}
    Dim pMarginsOFF As New MARGINS With {.Su = 0, .Sinistra = 0, .Destra = 0, .Giu = 0}
    'WINDOWS AERO END
    Private updating As Boolean = False
    Private Sub UpdateStatusUpdater(strStatus As String)
        C4UL.Text = strStatus
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        updating = True
        UpdateHSL(ColorHelper.RGBtoHSL(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
        UpdateHSB(ColorHelper.RGBtoHSB(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
        UpdateCMYK(ColorHelper.RGBtoCMYK(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
        UpdateYUV(ColorHelper.RGBtoYUV(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
        updating = False
        'Update
        'UpdaterControl1.CheckForUpdates(New UpdateStatusCallback(AddressOf UpdateStatusUpdater), True)
    End Sub
#Region "Handlers"
    Private Sub RGBValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blueUD.ValueChanged, redUD.ValueChanged, greenUD.ValueChanged
        If updating = False Then
            preview.BackColor = Drawing.Color.FromArgb(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value))
            colorpanel.BackColor = Drawing.Color.FromArgb(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value))
            hexBox.Text = ColorHelper.RGBtoHEX(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value))

            updating = True
            UpdateHSL(ColorHelper.RGBtoHSL(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateHSB(ColorHelper.RGBtoHSB(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateCMYK(ColorHelper.RGBtoCMYK(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateYUV(ColorHelper.RGBtoYUV(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            updating = False
        End If
    End Sub
    Private Sub HSLValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hueUD.ValueChanged, satUD.ValueChanged, lumUD.ValueChanged
        If updating = False Then
            updating = True
            UpdateRGB(ColorHelper.HSLtoRGB(Convert.ToDouble(hueUD.Value), Convert.ToDouble(satUD.Value / 100.0), Convert.ToDouble(lumUD.Value / 100.0)))
            UpdateHSB(ColorHelper.RGBtoHSB(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateCMYK(ColorHelper.RGBtoCMYK(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateYUV(ColorHelper.RGBtoYUV(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            updating = False
        End If
    End Sub
    Private Sub HSBValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sUD.ValueChanged, hUD.ValueChanged, bUD.ValueChanged
        If updating = False Then
            updating = True
            UpdateRGB(ColorHelper.HSBtoRGB(Convert.ToDouble(hUD.Value), Convert.ToDouble(sUD.Value / 100.0), Convert.ToDouble(bUD.Value / 100.0)))
            UpdateHSL(ColorHelper.RGBtoHSL(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateCMYK(ColorHelper.RGBtoCMYK(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateYUV(ColorHelper.RGBtoYUV(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            updating = False
        End If
    End Sub
    Private Sub CMYKValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yellowUD.ValueChanged, magentaUD.ValueChanged, cyanUD.ValueChanged, blackUD.ValueChanged
        If updating = False Then
            updating = True
            UpdateRGB(ColorHelper.CMYKtoRGB(Convert.ToDouble(cyanUD.Value / 100.0), Convert.ToDouble(magentaUD.Value / 100.0), Convert.ToDouble(yellowUD.Value / 100.0), Convert.ToDouble(blackUD.Value / 100.0)))
            UpdateHSL(ColorHelper.RGBtoHSL(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateHSB(ColorHelper.RGBtoHSB(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateYUV(ColorHelper.RGBtoYUV(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            updating = False
        End If
    End Sub
    Private Sub YUVValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yUD.ValueChanged, vUD.ValueChanged, uUD.ValueChanged
        If updating = False Then
            updating = True
            UpdateRGB(ColorHelper.YUVtoRGB(Convert.ToDouble(yUD.Value / 100.0), (-0.436 + (Convert.ToDouble(uUD.Value / 100.0))), (-0.615 + (Convert.ToDouble(vUD.Value / 100.0)))))
            UpdateCMYK(ColorHelper.RGBtoCMYK(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateHSL(ColorHelper.RGBtoHSL(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            UpdateHSB(ColorHelper.RGBtoHSB(CInt(redUD.Value), CInt(greenUD.Value), CInt(blueUD.Value)))
            updating = False
        End If
    End Sub
#End Region
#Region "Updates"
    Private Sub UpdateRGB(ByVal rgb As RGB)
        If CInt(redUD.Value) <> rgb.Red Then
            redUD.Value = rgb.Red
        End If
        If CInt(greenUD.Value) <> rgb.Green Then
            greenUD.Value = rgb.Green
        End If
        If CInt(blueUD.Value) <> rgb.Blue Then
            blueUD.Value = rgb.Blue
        End If

        preview.BackColor = Drawing.Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue)
        colorpanel.BackColor = Drawing.Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue)
        hexBox.Text = ColorHelper.RGBtoHEX(rgb.Red, rgb.Green, rgb.Blue)
    End Sub
    Private Sub UpdateHSL(ByVal hsl As HSL)
        If CInt(hsl.Hue) <> CInt(hueUD.Value) Then
            hueUD.Value = CInt(hsl.Hue)
        End If
        If CInt(hsl.Saturation * 100) <> CInt(satUD.Value) Then
            satUD.Value = CInt(hsl.Saturation * 100)
        End If
        If CInt(hsl.Luminance * 100) <> CInt(lumUD.Value) Then
            lumUD.Value = CInt(hsl.Luminance * 100)
        End If
    End Sub
    Private Sub UpdateHSB(ByVal hsb As HSB)
        If CInt(hsb.Hue) <> CInt(hUD.Value) Then
            hUD.Value = CInt(hsb.Hue)
        End If
        If CInt(hsb.Saturation * 100) <> CInt(sUD.Value) Then
            sUD.Value = CInt(hsb.Saturation * 100)
        End If
        If CInt(hsb.Brightness * 100) <> CInt(bUD.Value) Then
            bUD.Value = CInt(hsb.Brightness * 100)
        End If
    End Sub
    Private Sub UpdateCMYK(ByVal cmyk As CMYK)
        If CInt(cmyk.Cyan * 100) <> CInt(magentaUD.Value) Then
            magentaUD.Value = CInt(cmyk.Cyan * 100)
        End If
        If CInt(cmyk.Magenta * 100) <> CInt(magentaUD.Value) Then
            magentaUD.Value = CInt(cmyk.Magenta * 100)
        End If
        If CInt(cmyk.Yellow * 100) <> CInt(yellowUD.Value) Then
            yellowUD.Value = CInt(cmyk.Yellow * 100)
        End If
        If CInt(cmyk.Black * 100) <> CInt(blackUD.Value) Then
            blackUD.Value = CInt(cmyk.Black * 100)
        End If
    End Sub
    Private Sub UpdateYUV(ByVal yuv As YUV)
        If CInt(yuv.Y * 100) <> CInt(yUD.Value) Then
            yUD.Value = CInt(yuv.Y * 100)
        End If
        If CInt((yuv.U + 0.436) * 100) <> CInt(uUD.Value) Then
            uUD.Value = CInt((yuv.U + 0.436) * 100)
        End If
        If CInt((yuv.V + 0.615) * 100) <> CInt(vUD.Value) Then
            vUD.Value = CInt((yuv.V + 0.615) * 100)
        End If
    End Sub
#End Region
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        about2.ShowDialog()
    End Sub
    Private Sub hexBox_TextChanged(sender As Object, e As System.EventArgs) Handles hexBox.TextChanged
        Select Case hexBox.Text.Trim
            'RAL 1000+
            Case "#BEDB7F" : RALBox.Text = "1000"
            Case "#C2B078" : RALBox.Text = "1001"
            Case "#C6A664" : RALBox.Text = "1002"
            Case "#E5BE01" : RALBox.Text = "1003"
            Case "#CDA434" : RALBox.Text = "1004"
            Case "#A98307" : RALBox.Text = "1005"
            Case "#E4A010" : RALBox.Text = "1006"
            Case "#DC9D00" : RALBox.Text = "1007"
            Case "#8A6642" : RALBox.Text = "1011"
            Case "#C7B446" : RALBox.Text = "1012"
            Case "#EAE6CA" : RALBox.Text = "1013"
            Case "#E1CC4F" : RALBox.Text = "1014"
            Case "#E6D690" : RALBox.Text = "1015"
            Case "#EDFF21" : RALBox.Text = "1016"
            Case "#F5D033" : RALBox.Text = "1017"
            Case "#F8F32B" : RALBox.Text = "1018"
            Case "#9E9764" : RALBox.Text = "1019"
            Case "#999950" : RALBox.Text = "1020"
            Case "#F3DA0B" : RALBox.Text = "1021"
            Case "#FAD201" : RALBox.Text = "1023"
            Case "#AEA04B" : RALBox.Text = "1024"
            Case "#FFFF00" : RALBox.Text = "1026"
            Case "#9D9101" : RALBox.Text = "1027"
            Case "#F4A900" : RALBox.Text = "1028"
            Case "#D6AE01" : RALBox.Text = "1032"
            Case "#F3A505" : RALBox.Text = "1033"
            Case "#EFA94A" : RALBox.Text = "1034"
            Case "#6A5D4D" : RALBox.Text = "1035"
            Case "#705335" : RALBox.Text = "1036"
            Case "#F39F18" : RALBox.Text = "1037"
                'RAL 2000+
            Case "#ED760E" : RALBox.Text = "2000"
            Case "#C93C20" : RALBox.Text = "2001"
            Case "#CB2821" : RALBox.Text = "2002"
            Case "#FF7514" : RALBox.Text = "2003"
            Case "#F44611" : RALBox.Text = "2004"
            Case "#FF2301" : RALBox.Text = "2005"
            Case "#FFA420" : RALBox.Text = "2007"
            Case "#F75E25" : RALBox.Text = "2008"
            Case "#F54021" : RALBox.Text = "2009"
            Case "#D84B20" : RALBox.Text = "2010"
            Case "#EC7C26" : RALBox.Text = "2011"
            Case "#E55137" : RALBox.Text = "2012"
            Case "#C35831" : RALBox.Text = "2013"
                'RAL 3000+
            Case "#AF2B1E" : RALBox.Text = "3000"
            Case "#A52019" : RALBox.Text = "3001"
            Case "#A2231D" : RALBox.Text = "3002"
            Case "#9B111E" : RALBox.Text = "3003"
            Case "#75151E" : RALBox.Text = "3004"
            Case "#5E2129" : RALBox.Text = "3005"
            Case "#412227" : RALBox.Text = "3007"
            Case "#642424" : RALBox.Text = "3009"
            Case "#781F19" : RALBox.Text = "3011"
            Case "#C1876B" : RALBox.Text = "3012"
            Case "#A12312" : RALBox.Text = "3013"
            Case "#D36E70" : RALBox.Text = "3014"
            Case "#EA899A" : RALBox.Text = "3015"
            Case "#B32821" : RALBox.Text = "3016"
            Case "#E63244" : RALBox.Text = "3017"
            Case "#D53032" : RALBox.Text = "3018"
            Case "#CC0605" : RALBox.Text = "3020"
            Case "#D95030" : RALBox.Text = "3022"
            Case "#F80000" : RALBox.Text = "3024"
            Case "#FE0000" : RALBox.Text = "3026"
            Case "#C51D34" : RALBox.Text = "3027"
            Case "#CB3234" : RALBox.Text = "3028"
            Case "#B32428" : RALBox.Text = "3031"
            Case "#721422" : RALBox.Text = "3032"
            Case "#B44C43" : RALBox.Text = "3033"
                'RAL 4000+
            Case "#6D3F5B" : RALBox.Text = "4001"
            Case "#922B3E" : RALBox.Text = "4002"
            Case "#DE4C8A" : RALBox.Text = "4003"
            Case "#641C34" : RALBox.Text = "4004"
            Case "#6C4675" : RALBox.Text = "4005"
            Case "#A03472" : RALBox.Text = "4006"
            Case "#4A192C" : RALBox.Text = "4007"
            Case "#924E7D" : RALBox.Text = "4008"
            Case "#A18594" : RALBox.Text = "4009"
            Case "#CF3476" : RALBox.Text = "4010"
            Case "#8673A1" : RALBox.Text = "4011"
            Case "#6C6874" : RALBox.Text = "4012"
                'RAL 5000+
            Case "#354D73" : RALBox.Text = "5000"
            Case "#1F3438" : RALBox.Text = "5001"
            Case "#20214F" : RALBox.Text = "5002"
            Case "#1D1E33" : RALBox.Text = "5003"
            Case "#18171C" : RALBox.Text = "5004"
            Case "#1E2460" : RALBox.Text = "5005"
            Case "#3E5F8A" : RALBox.Text = "5007"
            Case "#26252D" : RALBox.Text = "5008"
            Case "#025669" : RALBox.Text = "5009"
            Case "#0E294B" : RALBox.Text = "5010"
            Case "#231A24" : RALBox.Text = "5011"
            Case "#3B83BD" : RALBox.Text = "5012"
            Case "#1E213D" : RALBox.Text = "5013"
            Case "#606E8C" : RALBox.Text = "5014"
            Case "#2271B3" : RALBox.Text = "5015"
            Case "#063971" : RALBox.Text = "5017"
            Case "#3F888F" : RALBox.Text = "5018"
            Case "#1B5583" : RALBox.Text = "5019"
            Case "#1D334A" : RALBox.Text = "5020"
            Case "#256D7B" : RALBox.Text = "5021"
            Case "#252850" : RALBox.Text = "5022"
            Case "#49678D" : RALBox.Text = "5023"
            Case "#5D9B9B" : RALBox.Text = "5024"
            Case "#2A6478" : RALBox.Text = "5025"
            Case "#102C54" : RALBox.Text = "5026"
                'RAL 6000+
            Case "#316650" : RALBox.Text = "6000"
            Case "#287233" : RALBox.Text = "6001"
            Case "#2D572C" : RALBox.Text = "6002"
            Case "#424632" : RALBox.Text = "6003"
            Case "#1F3A3D" : RALBox.Text = "6004"
            Case "#2F4538" : RALBox.Text = "6005"
            Case "#3E3B32" : RALBox.Text = "6006"
            Case "#343B29" : RALBox.Text = "6007"
            Case "#39352A" : RALBox.Text = "6008"
            Case "#31372B" : RALBox.Text = "6009"
            Case "#35682D" : RALBox.Text = "6010"
            Case "#587246" : RALBox.Text = "6011"
            Case "#343E40" : RALBox.Text = "6012"
            Case "#6C7156" : RALBox.Text = "6013"
            Case "#47402E" : RALBox.Text = "6014"
            Case "#3B3C36" : RALBox.Text = "6015"
            Case "#1E5945" : RALBox.Text = "6016"
            Case "#4C9141" : RALBox.Text = "6017"
            Case "#57A639" : RALBox.Text = "6018"
            Case "#BDECB6" : RALBox.Text = "6019"
            Case "#2E3A23" : RALBox.Text = "6020"
            Case "#89AC76" : RALBox.Text = "6021"
            Case "#25221B" : RALBox.Text = "6022"
            Case "#308446" : RALBox.Text = "6024"
            Case "#3D642D" : RALBox.Text = "6025"
            Case "#015D52" : RALBox.Text = "6026"
            Case "#84C3BE" : RALBox.Text = "6027"
            Case "#2C5545" : RALBox.Text = "6028"
            Case "#20603D" : RALBox.Text = "6029"
            Case "#317F43" : RALBox.Text = "6032"
            Case "#497E76" : RALBox.Text = "6033"
            Case "#7FB5B5" : RALBox.Text = "6034"
            Case "#1C542D" : RALBox.Text = "6035"
            Case "#193737" : RALBox.Text = "6036"
            Case "#008F39" : RALBox.Text = "6037"
            Case "#00BB2D" : RALBox.Text = "6038"
                'RAL 7000+
            Case "#78858B" : RALBox.Text = "7000"
            Case "#8A9597" : RALBox.Text = "7001"
            Case "#7E7B52" : RALBox.Text = "7002"
            Case "#6C7059" : RALBox.Text = "7003"
            Case "#969992" : RALBox.Text = "7004"
            Case "#646B63" : RALBox.Text = "7005"
            Case "#6D6552" : RALBox.Text = "7006"
            Case "#6A5F31" : RALBox.Text = "7008"
            Case "#4D5645" : RALBox.Text = "7009"
            Case "#4C514A" : RALBox.Text = "7010"
            Case "#434B4D" : RALBox.Text = "7011"
            Case "#4E5754" : RALBox.Text = "7012"
            Case "#464531" : RALBox.Text = "7013"
            Case "#434750" : RALBox.Text = "7015"
            Case "#293133" : RALBox.Text = "7016"
            Case "#23282B" : RALBox.Text = "7021"
            Case "#332F2C" : RALBox.Text = "7022"
            Case "#686C5E" : RALBox.Text = "7023"
            Case "#474A51" : RALBox.Text = "7024"
            Case "#2F353B" : RALBox.Text = "7026"
            Case "#8B8C7A" : RALBox.Text = "7030"
            Case "#474B4E" : RALBox.Text = "7031"
            Case "#B8B799" : RALBox.Text = "7032"
            Case "#7D8471" : RALBox.Text = "7033"
            Case "#8F8B66" : RALBox.Text = "7034"
            Case "#D7D7D7" : RALBox.Text = "7035"
            Case "#7F7679" : RALBox.Text = "7036"
            Case "#7D7F7D" : RALBox.Text = "7037"
            Case "#B5B8B1" : RALBox.Text = "7038"
            Case "#6C6960" : RALBox.Text = "7039"
            Case "#9DA1AA" : RALBox.Text = "7040"
            Case "#8D948D" : RALBox.Text = "7041"
            Case "#4E5452" : RALBox.Text = "7043"
            Case "#CAC4B0" : RALBox.Text = "7044"
            Case "#909090" : RALBox.Text = "7045"
            Case "#82898F" : RALBox.Text = "7046"
            Case "#D0D0D0" : RALBox.Text = "7047"
            Case "#898176" : RALBox.Text = "7048"
                'RAL 8000+
            Case "#826C34" : RALBox.Text = "8000"
            Case "#955F20" : RALBox.Text = "8001"
            Case "#6C3B2A" : RALBox.Text = "8002"
            Case "#734222" : RALBox.Text = "8003"
            Case "#8E402A" : RALBox.Text = "8004"
            Case "#59351F" : RALBox.Text = "8007"
            Case "#6F4F28" : RALBox.Text = "8008"
            Case "#5B3A29" : RALBox.Text = "8011"
            Case "#592321" : RALBox.Text = "8012"
            Case "#382C1E" : RALBox.Text = "8014"
            Case "#633A34" : RALBox.Text = "8015"
            Case "#4C2F27" : RALBox.Text = "8016"
            Case "#45322E" : RALBox.Text = "8017"
            Case "#403A3A" : RALBox.Text = "8019"
            Case "#212121" : RALBox.Text = "8022"
            Case "#A65E2E" : RALBox.Text = "8023"
            Case "#79553D" : RALBox.Text = "8024"
            Case "#755C48" : RALBox.Text = "8025"
            Case "#4E3B31" : RALBox.Text = "8028"
            Case "#763C28" : RALBox.Text = "8029"
                'RAL 9000+
            Case "#FDF4E3" : RALBox.Text = "9001"
            Case "#E7EBDA" : RALBox.Text = "9002"
            Case "#F4F4F4" : RALBox.Text = "9003"
            Case "#282828" : RALBox.Text = "9004"
            Case "#0A0A0A" : RALBox.Text = "9005"
            Case "#A5A5A5" : RALBox.Text = "9006"
            Case "#8F8F8F" : RALBox.Text = "9007"
            Case "#FFFFFF" : RALBox.Text = "9010"
            Case "#1C1C1C" : RALBox.Text = "9011"
            Case "#F6F6F6" : RALBox.Text = "9016"
            Case "#1E1E1E" : RALBox.Text = "9017"
            Case "#D7D7D7" : RALBox.Text = "9018"
            Case "#9C9C9C" : RALBox.Text = "9022"
            Case "#828282" : RALBox.Text = "9023"
            Case Else : RALBox.Clear() 'None of the above matched, so clear the RALBox
        End Select
    End Sub
    Private Sub RALBox_TextChanged(sender As Object, e As System.EventArgs) Handles RALBox.TextChanged
        Select Case RALBox.Text.Trim
            'RAL 1000+
            Case "1000" : hexBox.Text = "#BEDB7F"
            Case "1001" : hexBox.Text = "#C2B078"
            Case "1002" : hexBox.Text = "#C6A664"
            Case "1003" : hexBox.Text = "#E5BE01"
            Case "1004" : hexBox.Text = "#E5BE01"
            Case "1005" : hexBox.Text = "#A98307"
            Case "1006" : hexBox.Text = "#E4A010"
            Case "1007" : hexBox.Text = "#DC9D00"
            Case "1011" : hexBox.Text = "#8A6642"
            Case "1012" : hexBox.Text = "#C7B446"
            Case "1013" : hexBox.Text = "#C7B446"
            Case "1014" : hexBox.Text = "#E1CC4F"
            Case "1015" : hexBox.Text = "#E6D690"
            Case "1016" : hexBox.Text = "#EDFF21"
            Case "1017" : hexBox.Text = "#F5D033"
            Case "1018" : hexBox.Text = "#F8F32B"
            Case "1019" : hexBox.Text = "#9E9764"
            Case "1020" : hexBox.Text = "#999950"
            Case "1021" : hexBox.Text = "#F3DA0B"
            Case "1023" : hexBox.Text = "#FAD201"
            Case "1024" : hexBox.Text = "#AEA04B"
            Case "1026" : hexBox.Text = "#FFFF00"
            Case "1027" : hexBox.Text = "#9D9101"
            Case "1028" : hexBox.Text = "#F4A900"
            Case "1032" : hexBox.Text = "#D6AE01"
            Case "1033" : hexBox.Text = "#F3A505"
            Case "1034" : hexBox.Text = "#EFA94A"
            Case "1035" : hexBox.Text = "#6A5D4D"
            Case "1036" : hexBox.Text = "#705335"
            Case "1037" : hexBox.Text = "#F39F18"
                'RAL 2000+
            Case "2000" : hexBox.Text = "#ED760E"
            Case "2001" : hexBox.Text = "#C93C20"
            Case "2002" : hexBox.Text = "#CB2821"
            Case "2003" : hexBox.Text = "#FF7514"
            Case "2004" : hexBox.Text = "#F44611"
            Case "2005" : hexBox.Text = "#FF2301"
            Case "2007" : hexBox.Text = "#FFA420"
            Case "2008" : hexBox.Text = "#F75E25"
            Case "2009" : hexBox.Text = "#F54021"
            Case "2010" : hexBox.Text = "#D84B20"
            Case "2011" : hexBox.Text = "#EC7C26"
            Case "2012" : hexBox.Text = "#E55137"
            Case "2013" : hexBox.Text = "#C35831"
                'RAL 3000+
            Case "3000" : hexBox.Text = "#AF2B1E"
            Case "3001" : hexBox.Text = "#A52019"
            Case "3002" : hexBox.Text = "#A2231D"
            Case "3003" : hexBox.Text = "#9B111E"
            Case "3004" : hexBox.Text = "#75151E"
            Case "3005" : hexBox.Text = "#5E2129"
            Case "3007" : hexBox.Text = "#412227"
            Case "3009" : hexBox.Text = "#642424"
            Case "3011" : hexBox.Text = "#781F19"
            Case "3012" : hexBox.Text = "#C1876B"
            Case "3013" : hexBox.Text = "#A12312"
            Case "3014" : hexBox.Text = "#D36E70"
            Case "3015" : hexBox.Text = "#EA899A"
            Case "3016" : hexBox.Text = "#B32821"
            Case "3017" : hexBox.Text = "#E63244"
            Case "3018" : hexBox.Text = "#D53032"
            Case "3020" : hexBox.Text = "#CC0605"
            Case "3022" : hexBox.Text = "#D95030"
            Case "3024" : hexBox.Text = "#F80000"
            Case "3026" : hexBox.Text = "#FE0000"
            Case "3027" : hexBox.Text = "#C51D34"
            Case "3028" : hexBox.Text = "#CB3234"
            Case "3031" : hexBox.Text = "#B32428"
            Case "3032" : hexBox.Text = "#721422"
            Case "3033" : hexBox.Text = "#B44C43"
                'RAL 4000+
            Case "4001" : hexBox.Text = "#6D3F5B"
            Case "4002" : hexBox.Text = "#922B3E"
            Case "4003" : hexBox.Text = "#DE4C8A"
            Case "4004" : hexBox.Text = "#641C34"
            Case "4005" : hexBox.Text = "#6C4675"
            Case "4006" : hexBox.Text = "#A03472"
            Case "4007" : hexBox.Text = "#4A192C"
            Case "4008" : hexBox.Text = "#924E7D"
            Case "4009" : hexBox.Text = "#A18594"
            Case "4010" : hexBox.Text = "#CF3476"
            Case "4011" : hexBox.Text = "#8673A1"
            Case "4012" : hexBox.Text = "#6C6874"
                'RAL 5000+
            Case "5000" : hexBox.Text = "#354D73"
            Case "5001" : hexBox.Text = "#1F3438"
            Case "5002" : hexBox.Text = "#20214F"
            Case "5003" : hexBox.Text = "#1D1E33"
            Case "5004" : hexBox.Text = "#18171C"
            Case "5005" : hexBox.Text = "#1E2460"
            Case "5007" : hexBox.Text = "#3E5F8A"
            Case "5008" : hexBox.Text = "#26252D"
            Case "5009" : hexBox.Text = "#025669"
            Case "5010" : hexBox.Text = "#0E294B"
            Case "5011" : hexBox.Text = "#231A24"
            Case "5012" : hexBox.Text = "#3B83BD"
            Case "5013" : hexBox.Text = "#1E213D"
            Case "5014" : hexBox.Text = "#606E8C"
            Case "5015" : hexBox.Text = "#2271B3"
            Case "5017" : hexBox.Text = "#063971"
            Case "5018" : hexBox.Text = "#3F888F"
            Case "5019" : hexBox.Text = "#1B5583"
            Case "5020" : hexBox.Text = "#1D334A"
            Case "5021" : hexBox.Text = "#256D7B"
            Case "5022" : hexBox.Text = "#252850"
            Case "5023" : hexBox.Text = "#49678D"
            Case "5024" : hexBox.Text = "#5D9B9B"
            Case "5025" : hexBox.Text = "#2A6478"
            Case "5026" : hexBox.Text = "#102C54"
                'RAL 6000+
            Case "6000" : hexBox.Text = "#316650"
            Case "6001" : hexBox.Text = "#287233"
            Case "6002" : hexBox.Text = "#2D572C"
            Case "6003" : hexBox.Text = "#424632"
            Case "6004" : hexBox.Text = "#1F3A3D"
            Case "6005" : hexBox.Text = "#2F4538"
            Case "6006" : hexBox.Text = "#3E3B32"
            Case "6007" : hexBox.Text = "#343B29"
            Case "6008" : hexBox.Text = "#39352A"
            Case "6009" : hexBox.Text = "#31372B"
            Case "6010" : hexBox.Text = "#35682D"
            Case "6011" : hexBox.Text = "#587246"
            Case "6012" : hexBox.Text = "#343E40"
            Case "6013" : hexBox.Text = "#6C7156"
            Case "6014" : hexBox.Text = "#47402E"
            Case "6015" : hexBox.Text = "#3B3C36"
            Case "6016" : hexBox.Text = "#1E5945"
            Case "6017" : hexBox.Text = "#4C9141"
            Case "6018" : hexBox.Text = "#57A639"
            Case "6019" : hexBox.Text = "#BDECB6"
            Case "6020" : hexBox.Text = "#2E3A23"
            Case "6021" : hexBox.Text = "#89AC76"
            Case "6022" : hexBox.Text = "#25221B"
            Case "6024" : hexBox.Text = "#308446"
            Case "6025" : hexBox.Text = "#3D642D"
            Case "6026" : hexBox.Text = "#015D52"
            Case "6027" : hexBox.Text = "#84C3BE"
            Case "6028" : hexBox.Text = "#2C5545"
            Case "6029" : hexBox.Text = "#20603D"
            Case "6032" : hexBox.Text = "#317F43"
            Case "6033" : hexBox.Text = "#497E76"
            Case "6034" : hexBox.Text = "#7FB5B5"
            Case "6035" : hexBox.Text = "#1C542D"
            Case "6036" : hexBox.Text = "#193737"
            Case "6037" : hexBox.Text = "#008F39"
            Case "6038" : hexBox.Text = "#00BB2D"
                'RAL 7000+
            Case "7000" : hexBox.Text = "#78858B"
            Case "7001" : hexBox.Text = "#8A9597"
            Case "7002" : hexBox.Text = "#7E7B52"
            Case "7003" : hexBox.Text = "#6C7059"
            Case "7004" : hexBox.Text = "#969992"
            Case "7005" : hexBox.Text = "#646B63"
            Case "7006" : hexBox.Text = "#6D6552"
            Case "7008" : hexBox.Text = "#6A5F31"
            Case "7009" : hexBox.Text = "#4D5645"
            Case "7010" : hexBox.Text = "#4C514A"
            Case "7011" : hexBox.Text = "#434B4D"
            Case "7012" : hexBox.Text = "#4E5754"
            Case "7013" : hexBox.Text = "#464531"
            Case "7015" : hexBox.Text = "#434750"
            Case "7016" : hexBox.Text = "#293133"
            Case "7021" : hexBox.Text = "#23282B"
            Case "7022" : hexBox.Text = "#332F2C"
            Case "7023" : hexBox.Text = "#686C5E"
            Case "7024" : hexBox.Text = "#474A51"
            Case "7026" : hexBox.Text = "#2F353B"
            Case "7030" : hexBox.Text = "#8B8C7A"
            Case "7031" : hexBox.Text = "#474B4E"
            Case "7032" : hexBox.Text = "#B8B799"
            Case "7033" : hexBox.Text = "#7D8471"
            Case "7034" : hexBox.Text = "#8F8B66"
            Case "7035" : hexBox.Text = "#D7D7D7"
            Case "7036" : hexBox.Text = "#7F7679"
            Case "7037" : hexBox.Text = "#7D7F7D"
            Case "7038" : hexBox.Text = "#B5B8B1"
            Case "7039" : hexBox.Text = "#6C6960"
            Case "7040" : hexBox.Text = "#9DA1AA"
            Case "7041" : hexBox.Text = "#8D948D"
            Case "7043" : hexBox.Text = "#4E5452"
            Case "7044" : hexBox.Text = "#CAC4B0"
            Case "7045" : hexBox.Text = "#909090"
            Case "7046" : hexBox.Text = "#82898F"
            Case "7047" : hexBox.Text = "#D0D0D0"
            Case "7048" : hexBox.Text = "#898176"
                'RAL 8000+
            Case "8000" : hexBox.Text = "#826C34"
            Case "8001" : hexBox.Text = "#955F20"
            Case "8002" : hexBox.Text = "#6C3B2A"
            Case "8003" : hexBox.Text = "#734222"
            Case "8004" : hexBox.Text = "#8E402A"
            Case "8007" : hexBox.Text = "#59351F"
            Case "8008" : hexBox.Text = "#6F4F28"
            Case "8011" : hexBox.Text = "#5B3A29"
            Case "8012" : hexBox.Text = "#592321"
            Case "8014" : hexBox.Text = "#382C1E"
            Case "8015" : hexBox.Text = "#633A34"
            Case "8016" : hexBox.Text = "#4C2F27"
            Case "8017" : hexBox.Text = "#45322E"
            Case "8019" : hexBox.Text = "#403A3A"
            Case "8022" : hexBox.Text = "#212121"
            Case "8023" : hexBox.Text = "#A65E2E"
            Case "8024" : hexBox.Text = "#79553D"
            Case "8025" : hexBox.Text = "#755C48"
            Case "8028" : hexBox.Text = "#4E3B31"
            Case "8029" : hexBox.Text = "#763C28"
                'RAL 9000+
            Case "9001" : hexBox.Text = "#FDF4E3"
            Case "9002" : hexBox.Text = "#E7EBDA"
            Case "9003" : hexBox.Text = "#F4F4F4"
            Case "9004" : hexBox.Text = "#282828"
            Case "9005" : hexBox.Text = "#0A0A0A"
            Case "9006" : hexBox.Text = "#A5A5A5"
            Case "9007" : hexBox.Text = "#8F8F8F"
            Case "9010" : hexBox.Text = "#FFFFFF"
            Case "9011" : hexBox.Text = "#1C1C1C"
            Case "9016" : hexBox.Text = "#F6F6F6"
            Case "9017" : hexBox.Text = "#1E1E1E"
            Case "9018" : hexBox.Text = "#D7D7D7"
            Case "9022" : hexBox.Text = "#9C9C9C"
            Case "9023" : hexBox.Text = "#828282"
        End Select
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "The RAL colors in this app have been matched as closely as possible. This app therefore can not serve as a standard for RAL Color Productions."
        style = MsgBoxStyle.OkOnly Or MsgBoxStyle.Information
        title = Application.ProductName + " - RAL Information"
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
        End If
    End Sub
    Private Sub main_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub SupportToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SupportToolStripMenuItem1.Click
        Process.Start("https://github.com/DanielRTRD/ColorConvertz0r/issues/new")
    End Sub
    Private Sub EnableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnableToolStripMenuItem.Click
        If System.Environment.OSVersion.Version.Major < 6 Or System.Environment.OSVersion.Version.Major = 6 And System.Environment.OSVersion.Version.Minor >= 2 Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "Your Windows does not support Windows Aero!"
            style = MsgBoxStyle.DefaultButton2 Or
                MsgBoxStyle.Information
            title = "ColorConvertz0r - Windows Aero"
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
            End If
        ElseIf System.Environment.OSVersion.Version.Major >= 6 And System.Environment.OSVersion.Version.Minor < 2 Then
            'Windows Aero
            Dim en As Boolean = False
            DwmIsCompositionEnabled(en)
            If en Then
                DwmExtendFrameIntoClientArea(Me.Handle, pMargins)
                DwmExtendFrameIntoClientArea(about2.Handle, pMargins)
            End If
            'transparent
            Me.TransparencyKey = Drawing.Color.FromKnownColor(KnownColor.ActiveCaption)
            Me.BackColor = Me.TransparencyKey
            about2.TransparencyKey = Drawing.Color.FromKnownColor(KnownColor.ActiveCaption)
            about2.BackColor = about2.TransparencyKey
        End If
    End Sub
    Private Sub DisableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DisableToolStripMenuItem.Click
        If System.Environment.OSVersion.Version.Major < 6 Or System.Environment.OSVersion.Version.Major = 6 And System.Environment.OSVersion.Version.Minor >= 2 Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "Your Windows does not support Windows Aero!"
            style = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Information
            title = "ColorConvertz0r - Windows Aero"
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
            End If
        ElseIf System.Environment.OSVersion.Version.Major >= 6 And System.Environment.OSVersion.Version.Minor < 2 Then
            'Windows Aero
            DwmExtendFrameIntoClientArea(Me.Handle, pMarginsOFF)
            DwmExtendFrameIntoClientArea(about2.Handle, pMarginsOFF)
            'transparent
            Me.TransparencyKey = Drawing.Color.FromKnownColor(KnownColor.ActiveCaption)
            Me.BackColor = Drawing.Color.WhiteSmoke
            about2.TransparencyKey = Drawing.Color.FromKnownColor(KnownColor.ActiveCaption)
            about2.BackColor = Drawing.Color.WhiteSmoke
        End If
    End Sub
    Private Sub OnlineHelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Process.Start("https://github.com/DanielRTRD/ColorConvertz0r/issues/new")
    End Sub
    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        Process.Start("https://github.com/DanielRTRD/ColorConvertz0r/releases")
    End Sub
    Private Sub ReportABugToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReportABugToolStripMenuItem.Click
        Process.Start("https://github.com/DanielRTRD/ColorConvertz0r/issues/new")
    End Sub
    Private Sub ExportAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportAllToolStripMenuItem.Click
        If System.IO.File.Exists(My.Computer.FileSystem.CurrentDirectory & "\cc_export_" & DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") & ".txt") Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "The file already exist!"
            style = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical
            title = "ColorConvertz0r - Export"
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
            Else
            End If
        Else
            Dim objwriter As New System.IO.StreamWriter(My.Computer.FileSystem.CurrentDirectory & "\cc_export_" & DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") & ".txt")
            objwriter.Write("ColorConvertz0r - Exported file on " & Date.Now.ToString)
            objwriter.WriteLine()
            objwriter.WriteLine()
            objwriter.Write("RGB: " & redUD.Text & ", " & greenUD.Text & ", " & blueUD.Text)
            objwriter.WriteLine()
            objwriter.Write("HSB: " & hUD.Text & ", " & sUD.Text & ", " & bUD.Text)
            objwriter.WriteLine()
            objwriter.Write("HSL: " & hueUD.Text & ", " & satUD.Text & ", " & lumUD.Text)
            objwriter.WriteLine()
            objwriter.Write("YUV: " & yUD.Text & ", " & uUD.Text & ", " & vUD.Text)
            objwriter.WriteLine()
            objwriter.Write("CMYK: " & cyanUD.Text & ", " & magentaUD.Text & ", " & yellowUD.Text & ", " & blackUD.Text)
            objwriter.WriteLine()
            objwriter.Write("HEX: " & hexBox.Text)
            objwriter.WriteLine()
            objwriter.Write("RAL: " & RALBox.Text)
            objwriter.WriteLine()
            objwriter.WriteLine()
            objwriter.WriteLine()
            objwriter.Write("Thanks for using ColorConvertz0r!")
            objwriter.WriteLine()
            objwriter.Write("https://www.infihex.com/")
            objwriter.Close()
            'msbox
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "The file has been exported to this location: " & vbNewLine & My.Computer.FileSystem.CurrentDirectory.ToString & vbNewLine & vbNewLine & "Do you want to open this folder?"
            style = MsgBoxStyle.YesNo Or MsgBoxStyle.Information
            title = "ColorConvertz0r - Export"
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
                Process.Start(My.Computer.FileSystem.CurrentDirectory)
            End If
        End If
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If System.IO.File.Exists(My.Computer.FileSystem.CurrentDirectory & "\cc_export_" & DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") & ".html") Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "The file already exist!"
            style = MsgBoxStyle.DefaultButton2 Or _
                MsgBoxStyle.Critical
            title = "ColorConvertz0r - Export"
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
            End If
        Else
            Dim objwriter As New System.IO.StreamWriter(My.Computer.FileSystem.CurrentDirectory & "\" & "cc_export_" & DateTime.Now.ToString("dd-MM-yyyy-HH_mm_ss") & ".html")
            objwriter.Write("<!DOCTYPE html>")
            objwriter.WriteLine()
            objwriter.Write("<html lang=" & Chr(34) & "en" & Chr(34) & ">")
            objwriter.WriteLine()
            objwriter.Write("<head>")
            objwriter.WriteLine()
            objwriter.Write("<title>ColorConvertz0r - Export</title>")
            objwriter.WriteLine()
            objwriter.Write("</head>")
            objwriter.WriteLine()
            objwriter.Write("<body>")
            objwriter.WriteLine()
            objwriter.Write("<h1>ColorConvertz0r - Export</h1>")
            objwriter.WriteLine()
            objwriter.Write("<p>ColorConvertz0r - Exported file on " & Date.Now.ToString & "</p>")
            objwriter.WriteLine()
            objwriter.Write("<br />")
            objwriter.WriteLine()
            objwriter.Write("<p><b>RGB: " & redUD.Text & ", " & greenUD.Text & ", " & blueUD.Text & "</b></p>")
            objwriter.WriteLine()
            objwriter.Write("<p><b>HSB: " & hUD.Text & ", " & sUD.Text & ", " & bUD.Text & "</b></p>")
            objwriter.WriteLine()
            objwriter.Write("<p><b>HSL: " & hueUD.Text & ", " & satUD.Text & ", " & lumUD.Text & "</b></p>")
            objwriter.WriteLine()
            objwriter.Write("<p><b>YUV: " & yUD.Text & ", " & uUD.Text & ", " & vUD.Text & "</b></p>")
            objwriter.WriteLine()
            objwriter.Write("<p><b>CMYK: " & cyanUD.Text & ", " & magentaUD.Text & ", " & yellowUD.Text & ", " & blackUD.Text & "</b></p>")
            objwriter.WriteLine()
            objwriter.Write("<p><b>HEX: " & hexBox.Text & "</b></p>")
            objwriter.WriteLine()
            objwriter.Write("<p><b>RAL: " & RALBox.Text & "</b></p>")
            objwriter.WriteLine()
            objwriter.Write("<table border=" & Chr(34) & "0" & Chr(34) & "bgcolor=" & Chr(34) & hexBox.Text & Chr(34) & "><tr><td width=" & Chr(34) & "256" & Chr(34) & _
                            " height=" & Chr(34) & "50" & Chr(34) & "></td></tr></table>")
            objwriter.WriteLine()
            objwriter.Write("<br /><br />")
            objwriter.WriteLine()
            objwriter.Write("<h3>Thanks for using ColorConvertz0r!</h3>")
            objwriter.WriteLine()
            objwriter.Write("<h3><a href=" & Chr(34) & "https://www.infihex.com/" & Chr(34) & ">https://www.infihex.com/</a></h3>")
            objwriter.WriteLine()
            objwriter.Write("</body>")
            objwriter.WriteLine()
            objwriter.Write("</html>")
            objwriter.Close()
            'msbox
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "The file has been exported to this location: " & vbNewLine & My.Computer.FileSystem.CurrentDirectory.ToString & vbNewLine & vbNewLine & "Do you want to open this folder?"
            style = MsgBoxStyle.YesNo Or MsgBoxStyle.Information
            title = "ColorConvertz0r - Export"
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then
                Process.Start(My.Computer.FileSystem.CurrentDirectory)
            End If
        End If
    End Sub
    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        If AlwaysOnTopToolStripMenuItem.Checked = True Then
            Me.TopMost = True
        ElseIf AlwaysOnTopToolStripMenuItem.Checked = False Then
            Me.TopMost = False
        Else
            'nothing
        End If
    End Sub
    Private Sub HomeageToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HomeageToolStripMenuItem.Click
        Process.Start("https://infihex.com/")
    End Sub
    Private Sub preview_DoubleClick(sender As System.Object, e As System.EventArgs) Handles preview.DoubleClick
        colorpanel.Show()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "- To open the Color Panel double click the color preview." & vbNewLine & "- Get more options by right-clicking the window." _
            & vbNewLine & vbNewLine & "Do you want to check the Wiki for more information?"

        style = MsgBoxStyle.YesNo Or MsgBoxStyle.Information
        title = "ColorConvertz0r - Color Panel Information"
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            Process.Start("https://github.com/DanielRTRD/ColorConvertz0r")
        ElseIf response = MsgBoxResult.No Then
            'nothing
        End If
    End Sub
End Class
