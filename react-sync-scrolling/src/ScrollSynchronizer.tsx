//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

import React from 'react';

interface ScrollSynchronizerProps {
  children: (state: ScrollSynchronizerState) => React.ReactNode
}

interface ScrollSynchronizerState {
  ref1: React.Ref<HTMLTextAreaElement>,
  ref2: React.Ref<HTMLTextAreaElement>
}

function ScrollSynchronizer(props: ScrollSynchronizerProps) {

  const ref1 = React.useRef<HTMLTextAreaElement>(null);
  const ref2 = React.useRef<HTMLTextAreaElement>(null);

  const active1 = React.useRef<boolean>(false);
  const active2 = React.useRef<boolean>(false);

  const handleMouseEnter1 = React.useCallback(() => {
    active1.current = true;
  }, []);

  const handleMouseEnter2 = React.useCallback(() => {
    active2.current = true;
  }, []);

  const handleMouseLeave1 = React.useCallback(() => {
    active1.current = false;
  }, []);

  const handleMouseLeave2 = React.useCallback(() => {
    active2.current = false;
  }, []);

  const handleScroll1 = React.useCallback(() => {
    if (active2.current) {
      return;
    }
    const { current: textarea1 } = ref1;
    if (textarea1 == null) {
      return;
    }
    const { current: textarea2 } = ref2;
    if (textarea2 == null) {
      return;
    }
    const clientHeight1 = textarea1.clientHeight;
    const scrollHeight1 = textarea1.scrollHeight;
    const scrollTop1 = textarea1.scrollTop;
    const scrollRate = scrollTop1 / (scrollHeight1 - clientHeight1);
    const clientHeight2 = textarea2.clientHeight;
    const scrollHeight2 = textarea2.scrollHeight;
    const scrollTop2 = scrollRate * (scrollHeight2 - clientHeight2);
    textarea2.scrollTo({ top: scrollTop2 });
  }, []);

  const handleScroll2 = React.useCallback(() => {
    if (active1.current) {
      return;
    }
    const { current: textarea1 } = ref1;
    if (textarea1 == null) {
      return;
    }
    const { current: textarea2 } = ref2;
    if (textarea2 == null) {
      return;
    }
    const clientHeight2 = textarea2.clientHeight;
    const scrollHeight2 = textarea2.scrollHeight;
    const scrollTop2 = textarea2.scrollTop;
    const scrollRate = scrollTop2 / (scrollHeight2 - clientHeight2);
    const clientHeight1 = textarea1.clientHeight;
    const scrollHeight1 = textarea1.scrollHeight;
    const scrollTop1 = scrollRate * (scrollHeight1 - clientHeight1);
    textarea1.scrollTo({ top: scrollTop1 });
  }, []);

  React.useEffect(() => {
    const { current: textarea1 } = ref1;
    if (textarea1 == null) {
      return;
    }
    const { current: textarea2 } = ref2;
    if (textarea2 == null) {
      return;
    }
    textarea1.addEventListener('mouseenter', handleMouseEnter1);
    textarea1.addEventListener('mouseleave', handleMouseLeave1);
    textarea1.addEventListener('scroll', handleScroll1);
    textarea2.addEventListener('mouseenter', handleMouseEnter2);
    textarea2.addEventListener('mouseleave', handleMouseLeave2);
    textarea2.addEventListener('scroll', handleScroll2);
    return () => {
      textarea1.removeEventListener('mouseenter', handleMouseEnter1);
      textarea1.removeEventListener('mouseleave', handleMouseLeave1);
      textarea1.removeEventListener('scroll', handleScroll1);
      textarea2.removeEventListener('mouseenter', handleMouseEnter2);
      textarea2.removeEventListener('mouseleave', handleMouseLeave2);
      textarea2.removeEventListener('scroll', handleScroll2);
    };
  }, [
    handleMouseEnter1,
    handleMouseEnter2,
    handleMouseLeave1,
    handleMouseLeave2,
    handleScroll1,
    handleScroll2
  ]);

  return props.children({
    ref1,
    ref2
  });

}

export default ScrollSynchronizer;
