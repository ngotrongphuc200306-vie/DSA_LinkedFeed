using System;
using System.Diagnostics;

namespace SingleLinkList.Scripts
{
    internal class Timing
    {
        private Stopwatch stopwatch;
        private long startingMemory;

        public Timing()
        {
            stopwatch = new Stopwatch();
        }

        public void StartTime()
        {
            // Ép hệ thống thu gom rác để kết quả đo bộ nhớ và thời gian chính xác hơn
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Lưu lượng bộ nhớ đang sử dụng (byte)
            startingMemory = GC.GetTotalMemory(true);

            stopwatch.Restart();
        }

        public void StopTime()
        {
            stopwatch.Stop();
        }

        // Lấy thời gian chạy dưới dạng ms (số thực để chính xác hơn)
        public double ResultMilliseconds()
        {
            // Sử dụng Ticks để đổi ra ms chính xác hơn ép kiểu long trực tiếp
            return (double)stopwatch.ElapsedTicks / TimeSpan.TicksPerMillisecond;
        }

        // ĐO BỘ NHỚ: Trả về lượng KB đã tiêu tốn thêm
        public double ResultMemoryKB()
        {
            long endMemory = GC.GetTotalMemory(false);
            long memoryUsed = endMemory - startingMemory;
            return memoryUsed / 1024.0; // Đổi từ Byte sang KB
        }

        public TimeSpan Result()
        {
            return stopwatch.Elapsed;
        }
    }
}