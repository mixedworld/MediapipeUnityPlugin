using System;
using System.Runtime.InteropServices;

namespace Mediapipe {
  public class Timestamp : MpResourceHandle {
    public Timestamp(IntPtr ptr) : base(ptr) {}

    public Timestamp(Int64 value) : base() {
      UnsafeNativeMethods.mp_Timestamp__l(value, out var ptr);
      this.ptr = ptr;
    }

    protected override void DisposeUnmanaged() {
      if (OwnsResource()) {
        UnsafeNativeMethods.mp_Timestamp__delete(ptr);
      }
      base.DisposeUnmanaged();
    }

    public Int64 Value() {
      return SafeNativeMethods.mp_Timestamp__Value(mpPtr);
    }

    public double Seconds() {
      return SafeNativeMethods.mp_Timestamp__Seconds(mpPtr);
    }

    public Int64 Microseconds() {
      return SafeNativeMethods.mp_Timestamp__Microseconds(mpPtr);
    }

    public bool IsSpecialValue() {
      return SafeNativeMethods.mp_Timestamp__IsSpecialValue(mpPtr);
    }

    public bool IsRangeValue() {
      return SafeNativeMethods.mp_Timestamp__IsRangeValue(mpPtr);
    }

    public bool IsAllowedInStream() {
      return SafeNativeMethods.mp_Timestamp__IsAllowedInStream(mpPtr);
    }

    public string DebugString() {
      UnsafeNativeMethods.mp_Timestamp__DebugString(mpPtr, out var strPtr).Assert();
      var str = Marshal.PtrToStringAnsi(strPtr);
      UnsafeNativeMethods.delete_array__PKc(strPtr);

      GC.KeepAlive(this);
      return str;
    }

    public Timestamp NextAllowedInStream() {
      UnsafeNativeMethods.mp_Timestamp__NextAllowedInStream(mpPtr, out var nextPtr).Assert();

      GC.KeepAlive(this);
      return new Timestamp(nextPtr);
    }

    public Timestamp PreviousAllowedInStream() {
      UnsafeNativeMethods.mp_Timestamp__PreviousAllowedInStream(mpPtr, out var prevPtr).Assert();

      GC.KeepAlive(this);
      return new Timestamp(prevPtr);
    }

    public static Timestamp FromSeconds(double seconds) {
      UnsafeNativeMethods.mp_Timestamp_FromSeconds__d(seconds, out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp Unset() {
      UnsafeNativeMethods.mp_Timestamp_Unset(out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp Unstarted() {
      UnsafeNativeMethods.mp_Timestamp_Unstarted(out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp PreStream() {
      UnsafeNativeMethods.mp_Timestamp_PreStream(out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp Min() {
      UnsafeNativeMethods.mp_Timestamp_Min(out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp Max() {
      UnsafeNativeMethods.mp_Timestamp_Max(out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp PostStream() {
      UnsafeNativeMethods.mp_Timestamp_PostStream(out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp OneOverPostStream() {
      UnsafeNativeMethods.mp_Timestamp_OneOverPostStream(out var ptr).Assert();

      return new Timestamp(ptr);
    }

    public static Timestamp Done() {
      UnsafeNativeMethods.mp_Timestamp_Done(out var ptr).Assert();

      return new Timestamp(ptr);
    }
  }
}