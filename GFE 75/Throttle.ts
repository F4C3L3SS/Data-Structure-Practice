// throttle limits a function call at most every X ms.
// when using throttle, it behaves like this below

// user types continuously for 1.2s.
// 0 ms 200 400 600  800   1000   1200
// a   an   ang angu angul angula angular

// without any trailing and leading options, default behavior is to call apis on 0ms, 1000ms (considering user has given 1000ms delay time)
// and further more if users types on for 2s, it ll get called again once.
//leading: true → runs immediately
// trailing: true → ❌ no extra call, also provides the last call with latest value user has entered

type ThrottleFunction<T extends any[]> = (...args: T) => any;
type ThrottleOptions = {
  leading?: boolean;
  trailing?: boolean;
};

export default function throttle<T extends any[]>(
  func: ThrottleFunction<T>,
  wait: number,
  options: ThrottleOptions = {}
): ThrottleFunction<T> {
  
  let lastCallTime = 0; // when fn was last executed
  let timeoutId: ReturnType<typeof setTimeout> | null = null;
  let lastArgs: T | null = null;
  let lastThis: ThisParameterType<T> | null = null;

  const { leading = true, trailing = true } = options;

  function invoke(time: number) {
    if (!lastArgs) return;

    lastCallTime = time;
    func.apply(lastThis, lastArgs);
    lastArgs = lastThis = null;
  }

  function throttled(this: any, ...args: T) {
    const now = Date.now();

    // if leading is false, block the very first call
    if (!lastCallTime && !leading) {
      lastCallTime = now;
    }

    const remaining = wait - (now - lastCallTime);

    // always store latest intent
    lastArgs = args;
    lastThis = this;

    // CASE 1: throttle window is over -> execute immediately
    if (remaining <= 0) {
      if (timeoutId) {
        clearTimeout(timeoutId);
        timeoutId = null;
      }
      invoke(now);
    }
    
    // CASE 2: still inside window -> maybe schedule trailing
    else if (trailing && !timeoutId) {
      timeoutId = setTimeout(() => {
        timeoutId = null;
        if (trailing && lastArgs) {
          invoke(Date.now());
        }
      }, remaining);
    }
  }

  throttled.cancel = () => {
    if (timeoutId) clearTimeout(timeoutId);

    timeoutId = lastArgs = lastThis = null;
    lastCallTime = 0;
  }

  return throttled;
}