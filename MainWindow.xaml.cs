using System;
using System.Diagnostics;
using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DADA;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
    }

    private void DadaButton_Click(object sender, RoutedEventArgs e)
    {
        ExecuteShutdown();
    }

    private async void ExecuteShutdown()
    {
        try
        {
            // 효과음 재생 (주석 처리)
            // PlaySound();
            // 안내 메시지 (0.7초 후 종료)
            MessageBox.Show("컴퓨터가 즉시 종료됩니다!\n(저장되지 않은 작업은 모두 사라집니다)", "다더!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            await Task.Delay(700);
            // 실제 종료 명령 (디버깅 시 주석 처리)
            var psi = new ProcessStartInfo("shutdown", "/p /f")
            {
                UseShellExecute = true,
                Verb = "runas"
            };
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"종료 명령 실행 실패: {ex.Message}");
        }
    }

    private void PlaySound()
    {
        try
        {
            var player = new SoundPlayer("Resources/dada.wav");
            player.Play();
        }
        catch { /* 파일 없으면 무시 */ }
    }

}